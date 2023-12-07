using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

         async void newDrink_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new drink_creator());
        }

        async void newIngredient_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ingredient_creator());
        }

        async void refresh_Clicked(object sender, EventArgs e)
        {
            await App.OFViewModel.GetOwnDrinks();
            await App.OFViewModel.GetOwnIngredients();
        }
    }
}