using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;

namespace Matrix.Infrastructure.Repositories;

public class RoleRepository(ApplicationDbContext _context) : IRoleRepository
{
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Role.ToListAsync();
    }
    public async Task<Role> GetByIdAsync(int id)
    {
        return await _context.Role.FindAsync(id).AsTask();
    }
    public async Task<Role> AddAsync(Role entity)
    {
        _context.Role.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task UpdateAsync(Role entity)
    {
        _context.Role.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Role entity)
    {
        _context.Role.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
