using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllCitysAsync(int stateid);
}
