using System;
using Thesis.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class friends : ContentPage
    {
        public friends()
        {
            BindingContext = App.FrViewModel;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.FrViewModel.GetFriends();
            App.MPViewModel.SetUser();
        }


        async void SearchButtonPressed(object sender, EventArgs e)
        {
            await App.FrViewModel.GetSearchResult();
        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.FrViewModel.AddFriend((User)sender);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}