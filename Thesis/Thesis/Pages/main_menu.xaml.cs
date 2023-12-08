using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class main_menu : TabbedPage
    {
        public main_menu()
        {
            Children.Add(new dashboard());
            Children.Add(new profile());
            Children.Add(new created_favourites_page());
            Children.Add(new friends());
            Children.Add(new toplist());
            Children.Add(new logout());
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
    }
}