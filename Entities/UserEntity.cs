using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class UserEntity
{
    [Key]
    public uint Id { get; set; }
    
    [StringLength(30)]
    public required string Username { get; set; }
    
    [StringLength(30)]
    public required string PasswordHash { get; set; }
    
    [StringLength(30)]
    public required string Phone { get; set; }
    
    [StringLength(30)]
    public required string Email { get; set; }
    
    [StringLength(30)]
    public required string FirstName { get; set; }
    
    [StringLength(30)]
    public required string SecondName { get; set; }
    
    public required string AvatarPicturePath { get; set; }
    
    public required UserStatusEnum Status { get; set; }
    
    public bool EmailVerified { get; set; }
    
    public bool PhoneVerified { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public DateTime LastLoginAt { get; set; }
}