﻿using System;
using Thesis.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Windows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registration_personal_data : ContentPage
    {
        public registration_personal_data()
        {
            this.BindingContext = App.RSViewModel;
            InitializeComponent();
        }
        async void Register(object sender, EventArgs e)
        {
            await App.RSViewModel.CreateUserAsync();
            await Navigation.PushAsync(new main_menu());


        }
    }
}