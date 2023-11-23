namespace Thesis.Repository
{
    public class DrinkDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string DrinksCollectionName { get; set; } = null!;
    }
}
