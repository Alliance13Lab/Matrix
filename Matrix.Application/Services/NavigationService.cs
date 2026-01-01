using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class NavigationService(
    INavigationRepository _navigationRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : INavigationService
{
    public async Task<IEnumerable<Navigation>> GetAllNavigationAsync(int id)
    {
        dynamic x;
        if (id > 0)
        {
            x = await _navigationRepository.GetByIdAsync(id);
            x = new List<Navigation> { x };
        }
        else
            x = await _navigationRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Navigation>>(x);
    }
    public async Task INUPNavigation(Navigation nav)
    {
        if (nav.Id > 0)
        {
            var x = await _navigationRepository.GetByIdAsync(nav.Id) ?? throw new ArgumentException("Data not found");
            _mapper.Map(nav, x);
            x.UpdatedBy = _identityService.GetUserId();
            await _navigationRepository.UpdateAsync(x);
        }
        else
        {
            var x = _mapper.Map<Navigation>(nav);
            x.CreatedBy = _identityService.GetUserId();
            var y = await _navigationRepository.AddAsync(x);
            _mapper.Map<Navigation>(y);
        }
    }
    public async Task DeleteNavigationAsync(int id)
    {
        var x = await _navigationRepository.GetByIdAsync(id) ?? throw new ArgumentException("Data not found");
        await _navigationRepository.DeleteAsync(x);
    }
}