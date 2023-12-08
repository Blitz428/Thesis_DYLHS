using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class profile : ContentPage
    {
        public profile()
        {
            BindingContext = App.PVViewModel;
            App.PVViewModel.GetUser();
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await App.PVViewModel.EditUserAsync();
            App.PVViewModel.SetEditable();
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            App.PVViewModel.SetEditable();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}