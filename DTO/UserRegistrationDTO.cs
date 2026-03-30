using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.DTO;

public class UserRegistrationDTO
{
    public IFormFile? AvatarPicture { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}