namespace Matrix.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
}
