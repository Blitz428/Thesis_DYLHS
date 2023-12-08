using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class IngredientCreatorViewModel : INotifyPropertyChanged
    {
        IRestService restService;
        public IngredientCreatorViewModel(IRestService service)
        {
            restService = service;
        }

        Ingredient ingredient;
        public Ingredient IngredientToSave { get { return ingredient; } set { ingredient = value; NotifyPropertyChanged(); } }

        public User CurrentUser { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Created_by { get; set; }

        public string Type { get; set; }

        public double Alcohol { get; set; }

        public double Kcal { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Carbon { get; set; }

        public bool Verified { get; set; }

        public async Task CreateIngredientAsync()
        {
            IngredientToSave = new Ingredient();
            CurrentUser = restService.User;
            IngredientToSave.Name = Name;
            IngredientToSave.Description = Description;
            IngredientToSave.Created_by = CurrentUser._Id;
            IngredientToSave.Type = Type;
            IngredientToSave.Alcohol = Alcohol;
            IngredientToSave.Kcal = Kcal;
            IngredientToSave.Fat = Fat;
            IngredientToSave.Protein = Protein;
            IngredientToSave.Carbon = Carbon;
            IngredientToSave.Avg_rating = 0;
            if (CurrentUser.Role.Equals("admin"))
            {
                IngredientToSave.Verified = true;
            }
            else
            {
                IngredientToSave.Verified = false;
            }


            await restService.SaveItemAsync<Ingredient>("http://10.0.2.2:5096/api/Ingredients", IngredientToSave, true);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
