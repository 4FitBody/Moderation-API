namespace Moderation_API.Infrastructure.SportSupplements.Repositories;

using Moderation_API.Core.SportSupplements.Models;
using Moderation_API.Core.SportSupplements.Repositories;
using MongoDB.Driver;


public class SportSupplementMongoRepository : ISportSupplementRepository
{
    private readonly IMongoDatabase supplementssDb;
    private readonly IMongoCollection<SportSupplement> collection;

    public SportSupplementMongoRepository(string connestionstring, string db, string collection)
    {
        var client = new MongoClient(connestionstring);

        this.supplementssDb = client.GetDatabase(db);

        this.collection = this.supplementssDb.GetCollection<SportSupplement>(collection);
    }

    public async Task<IEnumerable<SportSupplement>?> GetAllAsync()
    {
        var supplementss = await this.collection.FindAsync(f => f.IsApproved == false);

        var allsupplementss = supplementss.ToList();

        return allsupplementss;
    }

    public async Task<SportSupplement> GetByIdAsync(int id)
    {
        var supplements = await this.collection.FindAsync(e => e.Id == id);

        var searchedSportSupplement = supplements.FirstOrDefault();

        return searchedSportSupplement;
    }

    public async Task ApproveAsync(int id)
    {
        var update = Builders<SportSupplement>.Update.Set(_ => _.IsApproved, true);

        var options = new FindOneAndUpdateOptions<SportSupplement>();

        await this.collection.FindOneAndUpdateAsync<SportSupplement>(e => e.Id == id, update, options);
    }
}
