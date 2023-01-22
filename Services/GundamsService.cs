
using GundamApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GundamApi.Services;

public class GundamsService
{
    private readonly IMongoCollection<Gundam> _gundamsCollection;

    public GundamsService(
        IOptions<GundamDatabaseSettings> gundamDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            gundamDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            gundamDatabaseSettings.Value.DatabaseName);

        _gundamsCollection = mongoDatabase.GetCollection<Gundam>(
            gundamDatabaseSettings.Value.GundamsCollectionName);
    }

    public async Task<List<Gundam>> GetAsync() =>
        await _gundamsCollection.Find(_ => true).ToListAsync();

    public async Task<Gundam?> GetAsync(string id) =>
        await _gundamsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Gundam newGundam) =>
        await _gundamsCollection.InsertOneAsync(newGundam);

    public async Task UpdateAsync(string id, Gundam updatedGundam) =>
        await _gundamsCollection.ReplaceOneAsync(x => x.Id == id, updatedGundam);

    public async Task RemoveAsync(string id) =>
        await _gundamsCollection.DeleteOneAsync(x => x.Id == id);
}