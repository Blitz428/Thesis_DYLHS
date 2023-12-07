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
	public partial class dashboard : ContentPage
	{
		public dashboard ()
		{
			BindingContext = App.MPViewModel;
			App.MPViewModel.SetUser();

            InitializeComponent ();
		}
	}
}