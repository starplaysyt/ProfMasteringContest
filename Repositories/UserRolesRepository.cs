using Microsoft.EntityFrameworkCore;
using ProfMasteringProject.Entities;
using ProfMasteringProject.Persistence;

namespace ProfMasteringProject.Repositories;

public class UserRolesRepository(AppDbContext context)
{
    public async Task<UserRoleEntity?> GetUserRole(UserEntity user)
    {
        return (
            await context.UserUserRoles.Include(userUserRoleEntity => userUserRoleEntity.Permission)
            .FirstOrDefaultAsync(roles => roles.Role.Id == user.Id))?.Permission;
    }
}