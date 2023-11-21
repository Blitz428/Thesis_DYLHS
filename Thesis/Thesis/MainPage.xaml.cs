using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await Navigation.PushAsync(new Login());
        }
        async void Register_pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}
