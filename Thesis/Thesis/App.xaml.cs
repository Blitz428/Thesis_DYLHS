using System;
using Thesis.ViewModels;
using Thesis.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis
{
    public partial class App : Application
    {
        public static LoginScreenViewModel LSViewModel { get; private set; }

        public App()
        {
            
            LSViewModel = new LoginScreenViewModel(new RestService());
            MainPage = new NavigationPage(new Thesis.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
