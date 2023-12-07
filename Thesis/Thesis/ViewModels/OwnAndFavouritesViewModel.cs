using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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

        List<Drink> allDrinks;
        List<Drink> ownDrinks;
        public List<Drink> OwnDrinks { get { return ownDrinks; } set { ownDrinks = value; NotifyPropertyChanged(); } }
        public List<Drink> AllDrinks { get { return allDrinks; } set { allDrinks = value; NotifyPropertyChanged(); } }

        List<Ingredient> allIngredients;
        List<Ingredient> ownIngredients;
        public List<Ingredient> OwnIngredients { get { return ownIngredients; } set { ownIngredients = value; NotifyPropertyChanged(); } }
        public List<Ingredient> AllIngredients { get { return allIngredients; } set { allIngredients = value; NotifyPropertyChanged(); } }

        public async Task<List<Drink>> GetOwnDrinks()
        {
            user = restService.User;
            allDrinks = new List<Drink>();
            ownDrinks = new List<Drink>();
            allDrinks = await restService.RefreshDataAsync<Drink>("http://10.0.2.2:5096/api/Drinks");
            foreach (Drink drink in allDrinks)
            {
                if (drink.Created_by.Equals(user._Id))
                {
                    ownDrinks.Add(drink);
                }

            }
            return ownDrinks;

        }
        public async Task<List<Ingredient>> GetOwnIngredients()
        {
            user = restService.User;
            allIngredients = new List<Ingredient>();
            ownIngredients = new List<Ingredient>();
            allIngredients = await restService.RefreshDataAsync<Ingredient>("http://10.0.2.2:5096/api/Ingredients");
            foreach (Ingredient ingredient in allIngredients)
            {
                if (ingredient.Created_by.Equals(user._Id))
                {
                    ownIngredients.Add(ingredient);
                }

            }
            return ownIngredients;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
