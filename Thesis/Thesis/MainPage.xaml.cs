using System;
using Thesis.Windows;
using Xamarin.Forms;

namespace Thesis
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Login_pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new login_screen());
        }
        async void Register_pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registration_page());
        }
    }
}
