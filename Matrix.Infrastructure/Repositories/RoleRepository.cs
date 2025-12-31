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
    public Task DeleteAsync(Role entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(Role entity)
    {
        throw new NotImplementedException();
    }
}
