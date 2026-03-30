using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.DTO;

public class UserRegistrationDTO
{
    [Required(ErrorMessage = "Upload avatar")]
    public IFormFile AvatarPicture { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Password { get; set; }
}