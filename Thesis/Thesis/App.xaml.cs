using Thesis.ViewModels;
using Xamarin.Forms;

namespace Thesis
{
    public partial class App : Application
    {
        public static RestService restService { get; private set; }
        public static LoginScreenViewModel LSViewModel { get; private set; }
        public static RegistrationViewModel RSViewModel { get; private set; }
        public static MainPageViewModel MPViewModel { get; private set; }

        public App()
        {
            restService = new RestService();
            LSViewModel = new LoginScreenViewModel(restService);
            RSViewModel = new RegistrationViewModel(restService);
            MPViewModel = new MainPageViewModel(restService);
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
