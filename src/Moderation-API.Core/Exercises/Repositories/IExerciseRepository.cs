namespace Moderation_API.Core.Exercises.Repositories;

using Moderation_API.Core.Exercises.Models;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>?> GetAllAsync();
    Task<Exercise> GetByIdAsync(int id);
    Task ApproveAsync(int id);
}