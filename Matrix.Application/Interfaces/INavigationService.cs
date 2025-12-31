using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface INavigationService
{
    Task<IEnumerable<Navigation>> GetAllNavigationAsync(int id);
    Task INUPNavigation(int id, Navigation nav);
}
