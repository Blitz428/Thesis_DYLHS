using System;
using Thesis.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Windows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login_screen : ContentPage
    {


        public login_screen()
        {
            this.BindingContext = App.LSViewModel;

            InitializeComponent();
        }


        async void Login_(object sender, EventArgs e)
        {

            await App.LSViewModel.FindUserAsync();
            if (App.restService.CredentialChecker[0].Equals(true))
            {
                await DisplayAlert("Hiba", "Hibás jelszó.", "OK");
            }
            else
            if (App.restService.CredentialChecker[1].Equals(true))
            {
                await DisplayAlert("Hiba", "Hibás felhasználónév vagy jelszó.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new main_menu());
            }


        }

        async void Forgot_password(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new forgot_pass());
        }
    }
}