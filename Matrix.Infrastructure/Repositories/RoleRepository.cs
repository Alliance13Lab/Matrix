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

    public Task<Role> AddAsync(Role entity)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteAsync(Role entity)
    {
        _context.Role.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public Task UpdateAsync(Role entity)
    {
        throw new NotImplementedException();
    }
}
