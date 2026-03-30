using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.DTO;

public class UserLoginDTO
{
    [Required(ErrorMessage = "Username is required")]
    public required string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; set; }
    
    [Required(ErrorMessage = "Remember me required")]
    public required string RememberMe { get; set; }
}