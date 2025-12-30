using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class CityService(
    ICityRepository _cityRepository,
    IMapper _mapper,
    IIdentityService _identityService
    ) : ICityService
{
    public async Task<IEnumerable<City>> GetAllCitysAsync(int stateid)
    {
        var x = await _cityRepository.GetAllAsync(stateid);
        return _mapper.Map<IEnumerable<City>>(x);

        //throw new NotImplementedException();
    }
}