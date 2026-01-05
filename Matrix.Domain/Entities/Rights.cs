namespace Matrix.Domain.Entities;

public class Rights : BaseEntity
{
    public int NavigationId { get; set; }
    public int RoleId { get; set; }
    public int UserId { get; set; }
    public bool CView { get; set; }
    public bool COp { get; set; }
    public bool IsDeleted { get; set; } = false;
}
