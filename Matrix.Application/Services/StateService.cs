using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class StateService(
    IStateRepository _stateRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : IStateService
{
    public async Task<IEnumerable<State>> GetAllStatesAsync()
    {
        var x = await _stateRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<State>>(x);

        //throw new NotImplementedException();
    }
}