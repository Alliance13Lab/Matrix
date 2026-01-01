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
    public async Task INUPRole(Role nav)
    {
        if (nav.Id > 0)
        {
            var x = await _roleRepository.GetByIdAsync(nav.Id) ?? throw new ArgumentException("Data not found");
            x.UpdatedBy = _identityService.GetUserId();
            x.Name = nav.Name;
            x.Description = nav.Description;
            x.IsDeleted = nav.IsDeleted;
            await _roleRepository.UpdateAsync(x);
        }
        else
        {
            var x = _mapper.Map<Role>(nav);
            x.CreatedBy = _identityService.GetUserId();
            var y = await _roleRepository.AddAsync(x);
            _mapper.Map<Role>(y);
        }
    }
    public async Task DeleteRoleAsync(int id)
    {
        var x = await _roleRepository.GetByIdAsync(id) ?? throw new ArgumentException("Data not found");
        await _roleRepository.DeleteAsync(x);
    }
}