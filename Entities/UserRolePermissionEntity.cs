using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class UserRolePermissionEntity
{
    [Key]
    public uint Id { get; set; }
    
    public required UserRoleEntity Role { get; set; }
    
    public required UserRolePermissionEntity Permission { get; set; }
}