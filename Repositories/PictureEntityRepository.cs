using Microsoft.EntityFrameworkCore;
using ProfMasteringProject.Entities;
using ProfMasteringProject.Persistence;

namespace ProfMasteringProject.Repositories;

public class PictureEntityRepository(AppDbContext context)
{
    public async Task<PictureEntity?> GetPictureById(Guid id)
    {
        return await context.Pictures.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddPicture(string? name = null)
    {
        await context.Pictures.AddAsync(new PictureEntity());
        await context.SaveChangesAsync();
    }
}