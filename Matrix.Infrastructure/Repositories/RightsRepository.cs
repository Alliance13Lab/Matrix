using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Infrastructure.Repositories;

public class RightsRepository(ApplicationDbContext _context) : IRightsRepository
{
    public async Task<IEnumerable<Rights>> GetAllAsync()
    {
        return await _context.Set<Rights>().ToListAsync();
    }

    public async Task<Rights> GetByIdAsync(int id)
    {
        return await _context.Set<Rights>().FindAsync(id).AsTask();
    }

    public async Task<Rights> AddAsync(Rights entity)
    {
        _context.Set<Rights>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Rights entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;
        _context.Set<Rights>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Rights entity)
    {
        _context.Set<Rights>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
