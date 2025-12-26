namespace Matrix.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; } = 0;
    public int RoleId { get; set; } = 0;
    public int CountryId { get; set; } = 0;
    public int StateId { get; set; } = 0;
    public int CityId { get; set; } = 0;
    public int DesignationId { get; set; } = 0;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public DateTime JoiningDate { get; set; }
    public string Address { get; set; }
    public string Mobile { get; set; }
    public string PersonalEmail { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime PasswordUpdateDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
