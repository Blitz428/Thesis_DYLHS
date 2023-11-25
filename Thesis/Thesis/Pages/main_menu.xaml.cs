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
    public partial class main_menu : TabbedPage
    {
        public main_menu()
        {
            Children.Add(new dashboard());
            
            InitializeComponent();
        }
    }
}