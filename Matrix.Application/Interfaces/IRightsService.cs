using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface IRightsService
{
    Task<IEnumerable<Rights>> GetAllRightsAsync(int id);
    Task INUPRights(Rights m);
    Task DeleteRightsAsync(int id);
}
