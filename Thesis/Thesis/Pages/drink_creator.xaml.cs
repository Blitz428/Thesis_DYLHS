﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class drink_creator : ContentPage
    {
        public drink_creator()
        {
            BindingContext = App.DCViewModel;
            InitializeComponent();
        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            await App.DCViewModel.CreateDrinkAsync();
            await Navigation.PopAsync();
        }
    }
}