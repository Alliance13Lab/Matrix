using Matrix.Domain.Entities;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Interfaces;

public interface IModuleService
{
    Task<IEnumerable<Module>> GetAllModuleAsync(int id);
}
