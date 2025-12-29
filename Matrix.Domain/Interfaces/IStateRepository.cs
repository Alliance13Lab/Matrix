using Matrix.Domain.Entities;
using Matrix.Shared;

namespace Matrix.Domain.Interfaces;

public interface IStateRepository //: IRepository<State>
{
    Task<IEnumerable<State>> GetAllAsync();
}
