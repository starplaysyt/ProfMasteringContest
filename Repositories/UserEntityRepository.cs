using Microsoft.EntityFrameworkCore;
using ProfMasteringProject.Entities;
using ProfMasteringProject.Persistence;

namespace ProfMasteringProject.Repositories;

public class UserEntityRepository(AppDbContext context)
{
    public async Task<UserEntity?> GetUserEntityByUsername(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddUserEntity(UserEntity userEntity)
    {
        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
    }

    public async Task<List<UserEntity>> GetUserEntities(Func<UserEntity, bool> predicate)
    {
        return context.Users.Where(predicate).ToList();
    }
}