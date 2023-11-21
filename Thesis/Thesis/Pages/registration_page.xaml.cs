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
            InitializeComponent();
        }

        async void Next(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registration_personal_data());

        }
    }
}