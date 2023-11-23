using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Models;
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
            
               await Navigation.PushAsync(new main_menu());
            
        }

        async void Forgot_password(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new forgot_pass());
        }
    }
}