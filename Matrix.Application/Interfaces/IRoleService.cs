using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRoleAsync(int id);
    Task DeleteRoleAsync(int id);
}
