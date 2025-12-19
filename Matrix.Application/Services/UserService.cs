using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class UserService(
    IUserRepository _userRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : IUserService
{
    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<PagedResult<User>> GetUsersAsync(UsersRequest request)
    {
        var result = await _userRepository.GetUsersAsync(request.Page, request.PageSize, request.SortColumn, request.SortDirection);
        return result;
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        if (await _userRepository.EmailExistsAsync(createUserDto.Email))
        {
            throw new ArgumentException("Email already exists");
        }

        var user = _mapper.Map<User>(createUserDto);
        user.Id = 2; // Temporary hardcoded value
        user.CreatedBy = _identityService.GetUserId();
        var createdUser = await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(createdUser);
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new ArgumentException("User not found");
        _mapper.Map(updateUserDto, user);
        user.UpdatedBy = _identityService.GetUserId();
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id) ?? throw new ArgumentException("User not found");
        await _userRepository.DeleteAsync(user);
    }
}