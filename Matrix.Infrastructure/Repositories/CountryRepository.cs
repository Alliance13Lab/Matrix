using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Matrix.Infrastructure.Repositories;

public class CountryRepository(ApplicationDbContext _context) : ICountryRepository
{
    public Task<Country> AddAsync(Country entity)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Country entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(Country entity)
    {
        throw new NotImplementedException();
    }

    public Task<Country> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    //public async Task<Country> GetByIdAsync(int id)
    //{
    //    return await _context.Country.FindAsync(id);
    //}

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Country.ToListAsync();
    }
    public async Task<List<Country>> GetCountryAsync(int page, int pageSize, string sortColumn, string sortDirection)
    {
        //return await _context.Country
        //    .AsNoTracking()
        //    .ToPagedResultAsync(page, pageSize, sortColumn, sortDirection);

        var items = await _context.Country
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return items;
    }

}
