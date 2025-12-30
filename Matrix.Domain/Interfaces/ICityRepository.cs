using Matrix.Domain.Entities;
using Matrix.Shared;

namespace Matrix.Domain.Interfaces;

public interface ICityRepository //: IRepository<City>
{
    Task<IEnumerable<City>> GetAllAsync(int stateid);
}
