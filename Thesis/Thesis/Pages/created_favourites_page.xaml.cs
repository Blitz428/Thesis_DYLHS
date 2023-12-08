using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class created_favourites_page : ContentPage
    {
        public created_favourites_page()
        {
            BindingContext = App.OFViewModel;

            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.OFViewModel.GetOwnDrinks();
            App.OFViewModel.GetOwnIngredients();
            App.MPViewModel.SetUser();
        }

        async void newDrink_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new drink_creator());
        }

        async void newIngredient_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ingredient_creator());
        }

    }
}