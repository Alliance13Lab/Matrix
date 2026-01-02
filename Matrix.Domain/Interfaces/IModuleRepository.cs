using Matrix.Domain.Entities;
using Matrix.Shared;

namespace Matrix.Domain.Interfaces;

public interface IModuleRepository : IRepository<Module>
{
    //Task<IEnumerable<State>> GetAllAsync(int id);
    //Task<dynamic> GetByIdAsync(int id);
}
