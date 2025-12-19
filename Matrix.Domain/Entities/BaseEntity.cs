
namespace Matrix.Domain.Entities;

public class BaseEntity : IEntity<int>, IFullAuditable
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int? UpdatedBy { get; set; }

}
public interface IEntity<T>
{
    T Id { get; set; }
}

public interface ICreationAuditable
{
    DateTime CreatedOn { get; set; }
    int CreatedBy { get; set; }
}

public interface IModificationAuditable
{
    DateTime? UpdatedOn { get; set; }
    int? UpdatedBy { get; set; }
}

public interface IFullAuditable : ICreationAuditable, IModificationAuditable
{
}

public interface IActiveStatus
{
    bool IsActive { get; set; }
}

public interface IDeleteStatus
{
    bool IsDeleted { get; set; }
}
