using Microsoft.EntityFrameworkCore;
using ProfMasteringProject.Entities;

namespace ProfMasteringProject.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<DataRoleEntity> DataRoles { get; set; }
    
    public DbSet<PermissionEntity> Permissions { get; set; }
    
    public DbSet<PictureDataRoleEntity> PictureDataRoles { get; set; }
    
    public DbSet<PictureEntity> Pictures { get; set; }
    
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<UserRoleEntity> UserRoles { get; set; }
    
    public DbSet<UserRolePermissionEntity> UserRolePermissions { get; set; }
    
    public DbSet<UserUserRoleEntity> UserUserRoles { get; set; }
    
    public DbSet<VolunteerFormEntity> VolunteerForms { get; set; }
    
    public DbSet<VolunteerProfileEntity> VolunteerProfiles { get; set; }
}