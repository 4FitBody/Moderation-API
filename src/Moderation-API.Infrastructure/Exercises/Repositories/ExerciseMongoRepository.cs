namespace Moderation_API.Infrastructure.Exercises.Repositories;

using Moderation_API.Core.Exercises.Models;
using Moderation_API.Core.Exercises.Repositories;
using MongoDB.Driver;

public class ExerciseMongoRepository : IExerciseRepository
{
    private readonly IMongoDatabase exercisesDb;
    private readonly IMongoCollection<Exercise> collection;

    public ExerciseMongoRepository(string connestionstring, string db, string collection)
    {
        var client = new MongoClient(connestionstring);

        this.exercisesDb = client.GetDatabase(db);

        this.collection = this.exercisesDb.GetCollection<Exercise>(collection);
    }

    public async Task<IEnumerable<Exercise>?> GetAllAsync()
    {
        var exercises = await this.collection.FindAsync(f => f.IsApproved == false);

        var allexercises = exercises.ToList();

        return allexercises;
    }

    public async Task<Exercise> GetByIdAsync(int id)
    {
        var exercise = await this.collection.FindAsync(e => e.Id == id);

        var searchedExercise = exercise.FirstOrDefault();

        return searchedExercise;
    }

    public async Task ApproveAsync(int id)
    {
        var update = Builders<Exercise>.Update.Set(_ => _.IsApproved, true);

        var options = new FindOneAndUpdateOptions<Exercise>();

        await this.collection.FindOneAndUpdateAsync<Exercise>(e => e.Id == id, update, options);
    }
}