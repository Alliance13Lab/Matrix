using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;

namespace Matrix.Infrastructure.Repositories;

public class NavigationRepository(ApplicationDbContext _context) : INavigationRepository
{
    public async Task<IEnumerable<Navigation>> GetAllAsync()
    {
        return await _context.Navigation.ToListAsync();
    }
    public async Task<Navigation> GetByIdAsync(int id)
    {
        return await _context.Navigation.FindAsync(id).AsTask();
        //throw new NotImplementedException();
    }
    //public Task<Navigation> GetByIdAsync(int id)
    //{
    //    return _context.Navigation.FindAsync(id).AsTask();
    //    //throw new NotImplementedException();
    //}

    public Task<Navigation> AddAsync(Navigation entity)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Navigation entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(Navigation entity)
    {
        throw new NotImplementedException();
    }
}
