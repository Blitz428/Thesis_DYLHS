using Android.Service.Controls.Actions;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Windows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registration_page : ContentPage
    {
        public registration_page()
        {
            this.BindingContext = App.RSViewModel;
            InitializeComponent();
        }

        async void Next(object sender, EventArgs e)
        {
            bool[] checkers = new bool[3];
            await App.RSViewModel.CheckUserAsync();
            checkers = App.restService.CredentialChecker;
           
            if (checkers[0].Equals(true))
            {
                await DisplayAlert("Hiba", "Ez a felhasználónév foglalt, kérem próbálkozzon másikkal.", "OK");
            }else if (checkers[1].Equals(true))
            {
                await DisplayAlert("Hiba", "Ez az email már használatban van, kérem használjon másikat, vagy jelentkezzen be.", "OK");
            }else if (checkers[2].Equals(true))
            {
                await DisplayAlert("Hiba", "Ez a telefonszám már használatban van, kérem használjon másikat.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new registration_personal_data());
            }
            

        }

     
    }
}