using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class PictureEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [StringLength(30)]
    public string? InternalName { get; set; }
}