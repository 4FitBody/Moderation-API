namespace Moderation_API.Infrastructure.Food.Repositories;

using Moderation_API.Core.Food.Repositories;
using Moderation_API.Core.Food.Models;
using Moderation_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class FoodSqlRepository : IFoodRepository
{
    private readonly ModerationDbContext dbContext;

    public FoodSqlRepository(ModerationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task ApproveAsync(int id)
    {
        var searchedFood = await this.dbContext.Food.FirstOrDefaultAsync(exercise => exercise.Id == id);
    
        searchedFood!.IsApproved = true;

        await this.dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Food>?> GetAllAsync()
    {
        var food = this.dbContext.Food.AsEnumerable();

        return food;
    }

    public async Task<Food> GetByIdAsync(int id)
    {
        var food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.Id == id);

        return food;
    }
}
