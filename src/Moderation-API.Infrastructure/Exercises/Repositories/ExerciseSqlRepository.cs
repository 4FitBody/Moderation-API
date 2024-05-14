namespace Moderation_API.Infrastructure.Exercises.Repositories;

using Moderation_API.Core.Exercises.Models;
using Moderation_API.Core.Exercises.Repositories;
using Moderation_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ExerciseSqlRepository : IExerciseRepository
{
    private readonly ModerationDbContext dbContext;

    public ExerciseSqlRepository(ModerationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Exercise>?> GetAllAsync()
    {
        var exercises = this.dbContext.Exercises.AsEnumerable();

        return exercises;
    }

    public async Task<Exercise> GetByIdAsync(int id)
    {
        var searchedExercise = await this.dbContext.Exercises.FirstOrDefaultAsync(exercise => exercise.Id == id);
    
        return searchedExercise!;
    }

    public async Task ApproveAsync(int id)
    {
        var searchedExercise = await this.dbContext.Exercises.FirstOrDefaultAsync(exercise => exercise.Id == id);
    
        searchedExercise!.IsApproved = true;

        await this.dbContext.SaveChangesAsync();
    }
}