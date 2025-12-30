using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;

namespace Matrix.Infrastructure.Repositories;

public class CityRepository(ApplicationDbContext _context) : ICityRepository
{
    public async Task<IEnumerable<City>> GetAllAsync(int stateid)
    {
        return await _context.City
            .Where(s => s.StateId == stateid)
            .ToListAsync();
    }

    public Task<City> AddAsync(City entity)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(City entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(City entity)
    {
        throw new NotImplementedException();
    }
    public Task<City> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
