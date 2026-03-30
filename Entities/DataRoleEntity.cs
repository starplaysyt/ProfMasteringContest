using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class DataRoleEntity
{
    [Key]
    public uint Id { get; set; }
    
    [StringLength(30)]
    public required string RoleType { get; set; }
}