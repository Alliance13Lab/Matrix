using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface ICountryService
{
    //Task<UserDto> GetUserByIdAsync(int id);
    Task<IEnumerable<Country>> GetAllCountryAsync();    
    Task<List<Country>> GetCountryAsync(CountryRequest request);
    
    //Task<UserDto> CreateUserAsync(User createUserDto);
    //Task UpdateUserAsync(int id, User updateUserDto);
    //Task DeleteUserAsync(int id);
}