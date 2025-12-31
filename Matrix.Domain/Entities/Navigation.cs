namespace Matrix.Domain.Entities;

public class Navigation : BaseEntity
{
    public int NavigationId { get; set; }
    public int PNavigationId { get; set; }
    public int Seq { get; set; }
    public int ModuleId { get; set; }
    public string PageTitle { get; set; }
    public string PageName { get; set; }
    public string URL { get; set; }
    public bool NewTab { get; set; }
}
