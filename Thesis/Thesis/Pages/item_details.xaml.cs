using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class drink_details : ContentPage
    {
        public drink_details()
        {
            BindingContext = App.IDViewModel;
            App.IDViewModel.SetItemFromDashbard();
            App.IDViewModel.GetDrinkRatings();
            InitializeComponent();
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            App.MPViewModel.ConsumeItem(App.IDViewModel.Quantity);
            await Navigation.PopAsync();

        }

        async void Rate_Clicked(object sender, EventArgs e)
        {
            await App.IDViewModel.RateAsync();
            App.IDViewModel.GetDrinkRatings();
        }

        private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }
    }
}