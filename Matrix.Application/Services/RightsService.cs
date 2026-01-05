using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class RightsService(
    IRightsRepository _rightsRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : IRightsService
{
    public async Task<IEnumerable<Rights>> GetAllRightsAsync(int id)
    {
        dynamic x;
        if (id > 0)
        {
            x = await _rightsRepository.GetByIdAsync(id);
            x = new List<Rights> { x };
        }
        else
            x = await _rightsRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Rights>>(x);
    }

    public async Task INUPRights(Rights m)
    {
        if (m.Id > 0)
        {
            var existing = await _rightsRepository.GetByIdAsync(m.Id) ?? throw new ArgumentException("Data not found");

            // Map incoming values onto the tracked entity to avoid tracking duplicate instances
            _mapper.Map(m, existing);
            existing.UpdatedBy = _identityService.GetUserId();

            await _rightsRepository.UpdateAsync(existing);
        }
        else
        {
            var entity = _mapper.Map<Rights>(m);
            entity.CreatedBy = _identityService.GetUserId();
            var added = await _rightsRepository.AddAsync(entity);
            _mapper.Map<Rights>(added);
        }
    }

    public async Task DeleteRightsAsync(int id)
    {
        var x = await _rightsRepository.GetByIdAsync(id) ?? throw new ArgumentException("Data not found");
        await _rightsRepository.DeleteAsync(x);
    }
}
