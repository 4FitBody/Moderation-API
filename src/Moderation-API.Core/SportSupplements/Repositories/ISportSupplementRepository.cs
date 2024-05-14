namespace Moderation_API.Core.SportSupplements.Repositories;

using Moderation_API.Core.SportSupplements.Models;

public interface ISportSupplementRepository
{
    Task<IEnumerable<SportSupplement>> GetAllAsync();
    Task<SportSupplement> GetByIdAsync(int id);
    Task ApproveAsync(int id);
}
