using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class UserRoleEntity
{
    [Key]
    public uint Id { get; set; }
    
    [StringLength(30)]
    public required string Name { get; set; }
    
    [StringLength(30)]
    public required string DisplayName { get; set; }
    
    public required string Description { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime CreatedAt { get; set; }
}