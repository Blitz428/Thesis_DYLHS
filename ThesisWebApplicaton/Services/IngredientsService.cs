using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Thesis.Models;
using Thesis.Repository;

namespace ThesisApi.Services
{
    public class IngredientsService
    {
        private readonly IMongoCollection<Ingredient> _ingredientsCollection;
        public IngredientsService(
        IOptions<IngredientDatabaseSettings> ingredientDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                ingredientDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                ingredientDatabaseSettings.Value.DatabaseName);

            _ingredientsCollection = mongoDatabase.GetCollection<Ingredient>(
                ingredientDatabaseSettings.Value.IngredientsCollectionName);
        }

        public async Task<List<Ingredient>> GetAsync() =>
            await _ingredientsCollection.Find(_ => true).ToListAsync();

        public async Task<Ingredient?> GetAsync(string id) =>
            await _ingredientsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Ingredient newIngredient) =>
            await _ingredientsCollection.InsertOneAsync(newIngredient);

        public async Task UpdateAsync(string id, Ingredient updatedIngredient) =>
            await _ingredientsCollection.ReplaceOneAsync(x => x._Id == id, updatedIngredient);

        public async Task RemoveAsync(string id) =>
            await _ingredientsCollection.DeleteOneAsync(x => x._Id == id);
    }
}
