using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class main_menuFlyout : ContentPage
    {
        public ListView ListView;

        public main_menuFlyout()
        {
            InitializeComponent();

            BindingContext = new main_menuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class main_menuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<main_menuFlyoutMenuItem> MenuItems { get; set; }

            public main_menuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<main_menuFlyoutMenuItem>(new[]
                {
                    new main_menuFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new main_menuFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new main_menuFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new main_menuFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new main_menuFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}