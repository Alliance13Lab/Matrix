using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;

namespace Matrix.Infrastructure.Repositories;

public class ModuleRepository(ApplicationDbContext _context) : IModuleRepository
{
    public async Task<IEnumerable<Module>> GetAllAsync()
    {
        return await _context.Module.ToListAsync();
    }
    public async Task<Module> GetByIdAsync(int id)
    {
        return await _context.Module.FindAsync(id);
    }
    public Task<Module> AddAsync(Module entity)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Module entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(Module entity)
    {
        throw new NotImplementedException();
    }
}
