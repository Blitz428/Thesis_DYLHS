using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Thesis.Models;
using Thesis.Repository;

namespace ThesisApi.Services
{
    public class RatingsService
    {
        private readonly IMongoCollection<Rating> _ratingsCollection;
        public RatingsService(
        IOptions<RatingDatabaseSettings> ratingDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                ratingDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                ratingDatabaseSettings.Value.DatabaseName);

            _ratingsCollection = mongoDatabase.GetCollection<Rating>(
                ratingDatabaseSettings.Value.RatingsCollectionName);
        }

        public async Task<List<Rating>> GetAsync() =>
            await _ratingsCollection.Find(_ => true).ToListAsync();

        public async Task<Rating?> GetAsync(string id) =>
            await _ratingsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Rating newRating) =>
            await _ratingsCollection.InsertOneAsync(newRating);

        public async Task UpdateAsync(string id, Rating updatedRating) =>
            await _ratingsCollection.ReplaceOneAsync(x => x._Id == id, updatedRating);

        public async Task RemoveAsync(string id) =>
            await _ratingsCollection.DeleteOneAsync(x => x._Id == id);
    }
}
