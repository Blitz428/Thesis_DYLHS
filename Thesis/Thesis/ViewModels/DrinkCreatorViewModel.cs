using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class DrinkCreatorViewModel : INotifyPropertyChanged
    {
        IRestService restService;

        public DrinkCreatorViewModel(IRestService service)
        {
            restService = service;
        }

        Drink drink;
        public Drink DrinkToSave { get { return drink; } set { drink = value; } }

        User user;
        public User CurrentUser { get; set; }
        public string Created_by { get; set; }



        public string Drink_name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public double Alcohol { get; set; }

        public double Kcal { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Carbon { get; set; }

        public double Avg_rating { get; set; }

        public bool Verified { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<Ingredient> allIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> AllIngredients { get { return allIngredients; } set { allIngredients = value; NotifyPropertyChanged(); } }

        string searchInput;
        public string SearchInput { get { return searchInput; } set { searchInput = value; NotifyPropertyChanged(); } }

        ObservableCollection<Ingredient> searchResults = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> SearchResults { get { return searchResults; } set { searchResults = value; NotifyPropertyChanged(); } }


        public async Task<ObservableCollection<Ingredient>> GetAllIngredients()
        {
            return AllIngredients = await restService.RefreshDataAsync<Ingredient>("http://10.0.2.2:5096/api/Ingredients");
        }

        Ingredient selectedItem;
        public Ingredient SelectedItem { get { return selectedItem; } set { selectedItem = value; NotifyPropertyChanged(); } }


        ObservableCollection<Ingredient> addedIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> AddedIngredients { get { return addedIngredients; } set { addedIngredients = value; NotifyPropertyChanged(); } }

        public async Task<ObservableCollection<Ingredient>> GetSearchResult()
        {
            await GetAllIngredients();

            foreach (Ingredient item in AllIngredients)
            {

                if (item.Name.Contains(SearchInput))
                {
                    if (!SearchResults.Contains(item))
                    {
                        SearchResults.Add(item);
                    }

                }
            }
            return SearchResults;
        }

        Ingredient itemtoadd;

        public void AddIngredient(double quantity)
        {
            itemtoadd = new Ingredient();
            itemtoadd.Alcohol = selectedItem.Alcohol * quantity / 100;
            itemtoadd.Kcal = selectedItem.Kcal * quantity / 100;
            itemtoadd.Protein = selectedItem.Protein * quantity / 100;
            itemtoadd.Fat = selectedItem.Fat * quantity / 100;
            itemtoadd.Carbon = selectedItem.Carbon * quantity / 100;
            itemtoadd.Name = selectedItem.Name + " " + quantity + " g/ml";
            itemtoadd.Description = selectedItem.Description;
            itemtoadd._Id = selectedItem._Id;

            AddedIngredients.Add(itemtoadd);


        }



            public async Task CreateDrinkAsync()
        {
            DrinkToSave = new Drink();
            CurrentUser = restService.User;

            DrinkToSave.Created_by = CurrentUser._Id;
            DrinkToSave.Name = Drink_name;
            DrinkToSave.Description = Description;
            DrinkToSave.Type = Type;

            DrinkToSave.Alcohol = 0;
            DrinkToSave.Kcal = 0;
            DrinkToSave.Fat = 0;
            DrinkToSave.Protein = 0;
            DrinkToSave.Carbon = 0;

            DrinkToSave.Ingredients = new ObservableCollection<string>() { };
            DrinkToSave.Ratings = new ObservableCollection<string>();
            if (AddedIngredients.Count==0)
            {
                DrinkToSave.Alcohol = Alcohol;
                DrinkToSave.Kcal = Kcal;
                DrinkToSave.Fat = Fat;
                DrinkToSave.Protein = Protein;
                DrinkToSave.Carbon = Carbon;
            }
            else
            {
                foreach (Ingredient item in AddedIngredients)
                {
                    DrinkToSave.Alcohol += item.Alcohol;
                    DrinkToSave.Kcal += item.Kcal;
                    DrinkToSave.Fat += item.Fat;
                    DrinkToSave.Protein += item.Protein;
                    DrinkToSave.Carbon += item.Carbon;
                    DrinkToSave.Ingredients.Add(item.Name);
                }
            }

            DrinkToSave.Avg_rating = Avg_rating;
            if (CurrentUser.Role.Equals("admin"))
            {
                DrinkToSave.Verified = true;
            }
            else
            {
                DrinkToSave.Verified = false;
            }



            await restService.SaveItemAsync<Drink>("http://10.0.2.2:5096/api/Drinks", DrinkToSave, true);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
