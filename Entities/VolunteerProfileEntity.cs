using System.ComponentModel.DataAnnotations;

namespace ProfMasteringProject.Entities;

public class VolunteerProfileEntity
{
    [Key]
    public uint Id { get; set; }
    
    public required UserEntity User { get; set; }
    
    public required string Biography { get; set; }
    
    public required string Experience { get; set; }
    
    public required string[] Skills { get; set; }
    
    public bool HasCar { get; set; }
    
    public required string CarInfo { get; set; }
    
    public required string ServiceArea { get; set; }
    
    public required float Rating { get; set; }
    
    public required uint TotalHours { get; set; }
    
    public DateTime JoinedAt { get; set; }
    
    public required string Notes { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}