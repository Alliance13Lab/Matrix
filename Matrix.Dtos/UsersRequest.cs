namespace Matrix.Dtos;

public record UsersRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than or equal to 1")]
    public int Page { get; init; } = 1;

    [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100")]
    public int PageSize { get; init; } = 10;

    [RegularExpression(@"^(Id|Name|Email|CreatedOn|UpdatedOn)$", ErrorMessage = "SortColumn must be one of: Id, Name, Email, CreatedAt, UpdatedAt")]
    public string SortColumn { get; init; } = "CreatedOn";

    [RegularExpression("^(asc|desc)$", ErrorMessage = "SortDirection must be 'asc' or 'desc'")]
    public string SortDirection { get; init; } = "desc";
}
