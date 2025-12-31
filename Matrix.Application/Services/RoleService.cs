using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class RoleService(
    IRoleRepository _roleRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : IRoleService
{
    public async Task<IEnumerable<Role>> GetAllRoleAsync(int id)
    {
        dynamic x;
        if (id > 0)
        {
            x = await _roleRepository.GetByIdAsync(id);
            x = new List<Role> { x };
        }
        else
            x = await _roleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Role>>(x);

        //throw new NotImplementedException();
    }
}