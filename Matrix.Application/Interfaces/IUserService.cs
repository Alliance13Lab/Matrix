using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<PagedResult<User>> GetUsersAsync(UsersRequest request);
    Task<UserDto> CreateUserAsync(User createUserDto);
    Task UpdateUserAsync(int id, User updateUserDto);
    Task DeleteUserAsync(int id);
}
