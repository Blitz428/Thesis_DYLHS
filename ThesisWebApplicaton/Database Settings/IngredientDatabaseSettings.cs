namespace Thesis.Repository
{
    public class IngredientDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string IngredientsCollectionName { get; set; } = null!;
    }
}
