using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Thesis.Models;
using static Android.Content.ClipData;

namespace Thesis.ViewModels
{
    public class IngredientToAddViewModel : INotifyPropertyChanged
    {
        IRestService restService;
        DrinkCreatorViewModel drinkCreatorViewModel;
        public IngredientToAddViewModel(IRestService service, DrinkCreatorViewModel drinkCreatorViewModel)
        {
            restService = service;
            this.drinkCreatorViewModel = drinkCreatorViewModel;
            
        }
        Ingredient ingredientToAdd;
        public Ingredient IngredientToAdd { get { return ingredientToAdd; } set { ingredientToAdd = value; NotifyPropertyChanged(); } }

        double quantity;
        public double Quantity { get { return quantity; } set { quantity = value; NotifyPropertyChanged(); } }

        public void SetItem()
        {
            IngredientToAdd = drinkCreatorViewModel.SelectedItem;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
