namespace Matrix.Dtos;

public record CreateUserDto
{
    [Required]
    public int CompanyId { get; set; } = 0;
    [Required]
    public int RoleId { get; set; } = 0;
    [Required]
    public int CountryId { get; set; } = 0;
    [Required]
    public int StateId { get; set; } = 0;
    [Required]
    public int CityId { get; set; } = 0;
    [Required]
    public int DesignationId { get; set; } = 0;
    [Required]
    public int PositionId { get; set; } = 0;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public DateTime JoiningDate { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Mobile { get; set; }
    public string PersonalEmail { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public DateTime PasswordUpdateDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
