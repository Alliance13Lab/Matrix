using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Shared;

namespace Matrix.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext _context) : IUserRepository
{
    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<PagedResult<User>> GetUsersAsync(int page, int pageSize, string sortColumn, string sortDirection)
    {
        return await _context.User
            .AsNoTracking()
            .ToPagedResultAsync(page, pageSize, sortColumn, sortDirection);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.User
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.User
            .AnyAsync(u => u.Email == email);
    }

    public async Task<User> AddAsync(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
    }
}
