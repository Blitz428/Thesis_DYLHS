using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class friends : ContentPage
    {
        public friends()
        {
            BindingContext = App.FrViewModel;
            InitializeComponent();
        }

        async void Reload_Clicked(object sender, EventArgs e)
        {
            await App.FrViewModel.GetFriends();
        }

        async void SearchButtonPressed(object sender, EventArgs e)
        {
            await App.FrViewModel.GetSearchResult();
        }
    }
}