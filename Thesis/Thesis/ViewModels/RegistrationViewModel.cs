using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;
using Thesis.Models;
using Microsoft.Extensions.DependencyInjection;
using ThesisApi.Models;
using System.Runtime.CompilerServices;


namespace Thesis.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        User userToRegister;
        public User UserToRegister { get { return userToRegister; } }

        private string username = string.Empty;
        public string Username
        {
            get { return username; }
            set
            {
                if (value != null)
                {
                    username = value;
                    NotifyPropertyChanged();
                }

            }
        }

        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set
            {
                if (value != null)
                {
                    password = value;
                    NotifyPropertyChanged();
                }

            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
