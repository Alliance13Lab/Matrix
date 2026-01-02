using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class ModuleService(
    IModuleRepository _moduleRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : IModuleService
{
    public async Task<IEnumerable<Module>> GetAllModuleAsync(int id)
    {
        dynamic x;
        if (id > 0)
        {
            x = await _moduleRepository.GetByIdAsync(id);
            x = new List<Module> { x };
        }
        else
            x = await _moduleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Module>>(x);
    }
}