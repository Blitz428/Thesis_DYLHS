using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class drink_creator : ContentPage
    {
        public drink_creator()
        {
            BindingContext = App.DCViewModel;
            InitializeComponent();
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await App.DCViewModel.CreateDrinkAsync();
            await Navigation.PopAsync();
        }
        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ingredient_to_add());
        }

        async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            App.DCViewModel.SearchResults.Clear();
            await App.DCViewModel.GetSearchResult();
        }
    }
}