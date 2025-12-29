using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;

namespace Matrix.Infrastructure.Repositories;

public class StateRepository(ApplicationDbContext _context) : IStateRepository
{
    public async Task<IEnumerable<State>> GetAllAsync()
    {
        return await _context.State.ToListAsync();
    }

    public Task<State> AddAsync(State entity)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(State entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(State entity)
    {
        throw new NotImplementedException();
    }
    public Task<State> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
