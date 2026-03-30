using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class PictureDataRoleEntity
{
    [Key]
    public uint Id { get; set; }
    
    public required PictureEntity Picture { get; set; }
    
    public required DataRoleEntity DataRole { get; set; }
    
    [StringLength(30)]
    public required string RoleType { get; set; }
}