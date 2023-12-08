using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ingredient_creator : ContentPage
    {
        public ingredient_creator()
        {
            BindingContext = App.ICViewModel;
            InitializeComponent();
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await App.ICViewModel.CreateIngredientAsync();
            await Navigation.PopAsync();
        }
    }
}