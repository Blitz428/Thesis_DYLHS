using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class toplist : ContentPage
    {
        public toplist()
        {
            BindingContext = App.TlViewModel;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.TlViewModel.GetTopUsers();
            App.MPViewModel.SetUser();
        }
    }
}