using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Windows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registration_personal_data : ContentPage
    {
        public registration_personal_data()
        {
            InitializeComponent();
        }
        async void Register(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new main_menu());

        }
    }
}