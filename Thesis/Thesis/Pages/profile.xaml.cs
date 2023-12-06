using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Models;
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
    }
}