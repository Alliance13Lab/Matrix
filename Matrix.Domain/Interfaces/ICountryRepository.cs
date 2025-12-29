using Matrix.Domain.Entities;
using Matrix.Shared;

namespace Matrix.Domain.Interfaces;

public interface ICountryRepository //: IRepository<Country>
{
    //Task<PagedResult<Country>> GetAllCountryAsync(int page, int pageSize, string sortColumn, string sortDirection);
    Task<List<Country>> GetCountryAsync(int page, int pageSize, string sortColumn, string sortDirection);
}