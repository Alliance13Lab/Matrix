using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<PagedResult<User>> GetUsersAsync(UsersRequest request);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    Task DeleteUserAsync(int id);
}
