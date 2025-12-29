using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface IStateService
{
    Task<IEnumerable<State>> GetAllStatesAsync();
}
