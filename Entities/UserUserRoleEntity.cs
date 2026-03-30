using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class UserUserRoleEntity
{
    [Key]
    public uint Id { get; set; }
    
    public required UserEntity Role { get; set; }
    
    public required UserRoleEntity Permission { get; set; }
    
    public DateTime AssignedAt { get; set; }
    
    public UserEntity? AssignedBy { get; set; }
    
    public bool IsActive { get; set; }
}