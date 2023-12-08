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
    public partial class ingredient_to_add : ContentPage
    {
        public ingredient_to_add()
        {
            BindingContext = App.ITAViewModel;
            App.ITAViewModel.SetItem();
            InitializeComponent();
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            App.DCViewModel.AddIngredient(App.ITAViewModel.Quantity);
            await Navigation.PopAsync();

        }
    }
}