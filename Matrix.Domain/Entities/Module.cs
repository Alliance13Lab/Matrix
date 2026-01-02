namespace Matrix.Domain.Entities;

public class Module : BaseEntity
{
    public string Name { get; set; }
    public string Link { get; set; }
    public string Color { get; set; }
    public string NewSiteModuleLink { get; set; }
    public bool IsDeleted { get; set; } = false;
}
