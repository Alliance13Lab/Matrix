using Matrix.Application.Interfaces;
using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Dtos;
using Matrix.Shared;

namespace Matrix.Application.Services;

public class CountryService(
    ICountryRepository _countryRepository,
    IMapper _mapper //,IIdentityService _identityService
    ) : ICountryService
{
    public async Task<IEnumerable<Country>> GetAllCountryAsync()
    {
        //var country = await _countryRepository.GetAllAsync();
        //return _mapper.Map<IEnumerable<Country>>(country);

        throw new NotImplementedException();
    }
    public async Task<List<Country>> GetCountryAsync(CountryRequest request)
    {
        var result = await _countryRepository.GetCountryAsync(request.Page, request.PageSize, request.SortColumn, request.SortDirection);
        return result;
    }
}
