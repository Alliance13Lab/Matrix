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
        return await _context.Navigation.FindAsync(id);
        //throw new NotImplementedException();
    }
    public async Task<Navigation> AddAsync(Navigation entity)
    {
        _context.Navigation.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
        //throw new NotImplementedException();
    }
    public async Task DeleteAsync(Navigation entity)
    {
        _context.Navigation.Remove(entity);
        await _context.SaveChangesAsync();
        //throw new NotImplementedException();
    }
    public async Task UpdateAsync(Navigation entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;
        _context.Navigation.Update(entity);
        await _context.SaveChangesAsync();
        //throw new NotImplementedException();
    }
}
