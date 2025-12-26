namespace Matrix.Domain.Entities;

public class User : BaseEntity
{
    public int CompanyId { get; set; }
    public int RoleId { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public int DesignationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime JoiningDate { get; set; }
    public string Address { get; set; }
    public string Mobile { get; set; }
    public string PersonalEmail { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime PasswordUpdateDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
