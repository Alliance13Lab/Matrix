#nullable enable

namespace Matrix.Shared;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    // 🔹 Keyset cursor
    public object? NextCursor { get; set; }
}

public static class QueryableExtensions
{
    // ============================================================
    // OFFSET PAGINATION (existing)
    // ============================================================
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
        this IQueryable<T> query,
        int page,
        int pageSize,
        string? sortColumn,
        string? sortDirection)
    {
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;

        if (!string.IsNullOrWhiteSpace(sortColumn))
            query = ApplySorting(query, sortColumn, sortDirection);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<T>
        {
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            Items = items
        };
    }

    // ============================================================
    // METHOD WITH PROJECTION (DTO selector)
    // ============================================================
    public static async Task<PagedResult<TResult>> ToPagedResultAsync<T, TResult>(
        this IQueryable<T> query,
        int page,
        int pageSize,
        string? sortColumn,
        string? sortDirection,
        Expression<Func<T, TResult>> selector)
    {
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(sortColumn))
        {
            query = ApplySorting(query, sortColumn, sortDirection);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(selector)
            .ToListAsync();

        return new PagedResult<TResult>
        {
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            Items = items
        };
    }

    // ============================================================
    // KEYSET PAGINATION (ENTITY)
    // ============================================================
    public static async Task<PagedResult<T>> ToKeysetPagedResultAsync<T, TKey>(
        this IQueryable<T> query,
        Expression<Func<T, TKey>> keySelector,
        TKey? lastKey,
        int pageSize,
        bool descending = false)
        where TKey : IComparable<TKey>
    {
        if (pageSize <= 0) pageSize = 10;

        if (lastKey != null)
        {
            query = descending
                ? query.Where(BuildLessThan(keySelector, lastKey))
                : query.Where(BuildGreaterThan(keySelector, lastKey));
        }

        query = descending
            ? query.OrderByDescending(keySelector)
            : query.OrderBy(keySelector);

        var items = await query
            .Take(pageSize)
            .ToListAsync();

        var nextCursor = items.Count == pageSize
            ? (object?)keySelector.Compile()(items.Last())
            : null;

        return new PagedResult<T>
        {
            PageSize = pageSize,
            Items = items,
            NextCursor = nextCursor
        };
    }

    // ============================================================
    // KEYSET PAGINATION (DTO PROJECTION)
    // ============================================================
    public static async Task<PagedResult<TResult>> ToKeysetPagedResultAsync<T, TResult, TKey>(
        this IQueryable<T> query,
        Expression<Func<T, TKey>> keySelector,
        Expression<Func<T, TResult>> selector,
        TKey? lastKey,
        int pageSize,
        bool descending = false)
        where TKey : IComparable<TKey>
    {
        if (pageSize <= 0) pageSize = 10;

        if (lastKey != null)
        {
            query = descending
                ? query.Where(BuildLessThan(keySelector, lastKey))
                : query.Where(BuildGreaterThan(keySelector, lastKey));
        }

        query = descending
            ? query.OrderByDescending(keySelector)
            : query.OrderBy(keySelector);

        var items = await query
            .Take(pageSize)
            .Select(selector)
            .ToListAsync();

        return new PagedResult<TResult>
        {
            PageSize = pageSize,
            Items = items
        };
    }

    // ============================================================
    // HELPERS
    // ============================================================
    private static Expression<Func<T, bool>> BuildGreaterThan<T, TKey>(
        Expression<Func<T, TKey>> selector,
        TKey value)
    {
        var body = Expression.GreaterThan(
            selector.Body,
            Expression.Constant(value));

        return Expression.Lambda<Func<T, bool>>(body, selector.Parameters);
    }

    private static Expression<Func<T, bool>> BuildLessThan<T, TKey>(
        Expression<Func<T, TKey>> selector,
        TKey value)
    {
        var body = Expression.LessThan(
            selector.Body,
            Expression.Constant(value));

        return Expression.Lambda<Func<T, bool>>(body, selector.Parameters);
    }

    private static IQueryable<T> ApplySorting<T>(
        IQueryable<T> query,
        string sortColumn,
        string? sortDirection)
    {
        var property = typeof(T).GetProperty(
            sortColumn,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        if (property == null)
            return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        var propertyAccess = Expression.Property(parameter, property);
        var lambda = Expression.Lambda(propertyAccess, parameter);

        var method = sortDirection?.ToLower() == "desc"
            ? "OrderByDescending"
            : "OrderBy";

        var sortedQuery = Expression.Call(
            typeof(Queryable),
            method,
            new[] { typeof(T), property.PropertyType },
            query.Expression,
            Expression.Quote(lambda));

        return query.Provider.CreateQuery<T>(sortedQuery);
    }
}

#nullable disable
