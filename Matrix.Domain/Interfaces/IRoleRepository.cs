using Matrix.Domain.Entities;
using Matrix.Shared;

namespace Matrix.Domain.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    //Task<IEnumerable<Role>> GetAllAsync(int id);
}
