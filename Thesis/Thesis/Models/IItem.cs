namespace Thesis.Models
{
    public interface IItem
    {
        string _Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Type { get; set; }
        double Alcohol { get; set; }
        double Kcal { get; set; }
        double Fat { get; set; }
        double Protein { get; set; }
        double Carbon { get; set; }
        
        double Avg_rating { get; set; }

        bool Verified { get; set; }


    }
}
