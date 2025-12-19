using Matrix.Domain.Entities;
using Matrix.Shared;

namespace Matrix.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
    Task<PagedResult<User>> GetUsersAsync(int page, int pageSize, string sortColumn, string sortDirection);
}
