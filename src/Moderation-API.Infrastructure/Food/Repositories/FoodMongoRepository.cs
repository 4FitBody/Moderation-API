namespace Moderation_API.Infrastructure.Food.Repositories;

using Moderation_API.Core.Food.Repositories;
using Moderation_API.Core.Food.Models;
using MongoDB.Driver;

public class FoodMongoRepository : IFoodRepository
{
    private readonly IMongoDatabase foodDb;
    private readonly IMongoCollection<Food> collection;

    public FoodMongoRepository(string connestionstring, string db, string collection)
    {
        var client = new MongoClient(connestionstring);

        this.foodDb = client.GetDatabase(db);

        this.collection = this.foodDb.GetCollection<Food>(collection);
    }

    public async Task ApproveAsync(int id)
    {
        var update = Builders<Food>.Update.Set(_ => _.IsApproved, true);

        var options = new FindOneAndUpdateOptions<Food>();

        await this.collection.FindOneAndUpdateAsync<Food>(e => e.Id == id, update, options);
    }

    public async Task<IEnumerable<Food>?> GetAllAsync()
    {
        var food = await this.collection.FindAsync(f => f.IsApproved == false);

        var allfood = food.ToList();

        return allfood;
    }

    public async Task<Food> GetByIdAsync(int id)
    {
        var food = await this.collection.FindAsync(e => e.Id == id);

        var searchedFood = food.FirstOrDefault();

        return searchedFood;
    }
}
