namespace Moderation_API.Core.Food.Repositories;

using Moderation_API.Core.Food.Models;

public interface IFoodRepository
{
    Task<IEnumerable<Food>?> GetAllAsync();
    Task<Food> GetByIdAsync(int id);
    Task ApproveAsync(int id);
}
