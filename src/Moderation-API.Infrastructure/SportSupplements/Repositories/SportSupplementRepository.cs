namespace Moderation_API.Infrastructure.SportSupplements.Repositories;

using Moderation_API.Core.SportSupplements.Models;
using Moderation_API.Core.SportSupplements.Repositories;
using Moderation_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


public class SportSupplementRepository : ISportSupplementRepository
{
    private readonly ModerationDbContext dbContext;

    public SportSupplementRepository(ModerationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<SportSupplement>?> GetAllAsync()
    {
        var supplements = await this.dbContext.SportSupplements.ToListAsync();

        return supplements;
    }

    public async Task<SportSupplement> GetByIdAsync(int id)
    {
        var searchedSportSupplement = await this.dbContext.SportSupplements.FirstOrDefaultAsync(exercise => exercise.Id == id);
    
        return searchedSportSupplement!;
    }

    public async Task ApproveAsync(int id)
    {
        var searchedSupplement = await this.dbContext.SportSupplements.FirstOrDefaultAsync(exercise => exercise.Id == id);
    
        searchedSupplement!.IsApproved = true;

        await this.dbContext.SaveChangesAsync();
    }
}
