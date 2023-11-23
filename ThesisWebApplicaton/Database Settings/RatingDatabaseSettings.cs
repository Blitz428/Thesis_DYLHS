namespace Thesis.Repository
{
    public class RatingDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string RatingsCollectionName { get; set; } = null!;
    }
}
