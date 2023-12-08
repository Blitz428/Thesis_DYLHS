using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{

    public class OwnAndFavouritesViewModel : INotifyPropertyChanged
    {
        IRestService restService;
        public OwnAndFavouritesViewModel(IRestService service)
        {
            restService = service;
        }
        User user;
        public User User { get { return user; } set { user = value; } }

        ObservableCollection<Drink> ownDrinks = new ObservableCollection<Drink>();
        public ObservableCollection<Drink> OwnDrinks { get { return ownDrinks; } set { ownDrinks = value; NotifyPropertyChanged(); } }

        ObservableCollection<Drink> allDrinks = new ObservableCollection<Drink>();
        public ObservableCollection<Drink> AllDrinks { get { return allDrinks; } set { allDrinks = value; NotifyPropertyChanged(); } }

        ObservableCollection<Ingredient> ownIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> OwnIngredients { get { return ownIngredients; } set { ownIngredients = value; NotifyPropertyChanged(); } }

        ObservableCollection<Ingredient> allIngredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> AllIngredients { get { return allIngredients; } set { allIngredients = value; NotifyPropertyChanged(); } }

        public async Task  GetOwnDrinks()
        {
            user = restService.User;
            OwnDrinks.Clear();
            AllDrinks = await restService.RefreshDataAsync<Drink>("http://10.0.2.2:5096/api/Drinks");
            foreach (Drink drink in AllDrinks)
            {
                if (drink.Created_by.Equals(user._Id))
                {
                    OwnDrinks.Add(drink);
                }

            }
           

        }
        public async Task GetOwnIngredients()
        {
            OwnIngredients.Clear();
            user = restService.User;
            AllIngredients = await restService.RefreshDataAsync<Ingredient>("http://10.0.2.2:5096/api/Ingredients");
            foreach (Ingredient ingredient in AllIngredients)
            {
                if (ingredient.Created_by.Equals(user._Id))
                {
                    OwnIngredients.Add(ingredient);
                }

            }
            

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
