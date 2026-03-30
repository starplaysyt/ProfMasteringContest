using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class VolunteerFormEntity
{
    [Key]
    public uint Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Surname { get; set; }
    
    public required string Age { get; set; }
    
    public required string MobilePhone { get; set; }
    
    public required string Email { get; set; }
    
    public required string[] WannaDo { get; set; }
    
    public required string AvailableTime { get; set; }
    
    public required string PetExperience { get; set; }
    
    public required string WhereFoundUs { get; set; }
    
    public required bool DataProcessingAcceptation { get; set; }
}