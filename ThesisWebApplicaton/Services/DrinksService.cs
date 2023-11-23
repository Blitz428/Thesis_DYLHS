namespace ThesisApi.Services
{
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using Thesis.Models;
    using Thesis.Repository;

    public class DrinksService
    {
        private readonly IMongoCollection<Drink> _drinksCollection;
        public DrinksService(
        IOptions<DrinkDatabaseSettings> drinkDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                drinkDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                drinkDatabaseSettings.Value.DatabaseName);

            _drinksCollection = mongoDatabase.GetCollection<Drink>(
                drinkDatabaseSettings.Value.DrinksCollectionName);
        }

        public async Task<List<Drink>> GetAsync() =>
            await _drinksCollection.Find(_ => true).ToListAsync();

        public async Task<Drink?> GetAsync(string id) =>
            await _drinksCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Drink newDrink) =>
            await _drinksCollection.InsertOneAsync(newDrink);

        public async Task UpdateAsync(string id, Drink updatedDrink) =>
            await _drinksCollection.ReplaceOneAsync(x => x._Id == id, updatedDrink);

        public async Task RemoveAsync(string id) =>
            await _drinksCollection.DeleteOneAsync(x => x._Id == id);
    }


}

