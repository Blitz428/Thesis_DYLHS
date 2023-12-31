﻿using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class LoginScreenViewModel : INotifyPropertyChanged
    {
        IRestService restService;
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

        public LoginScreenViewModel(IRestService service)
        {
            restService = service;
        }
        public LoginScreenViewModel()
        {

        }

        public Task<User> FindUserAsync()
        {
            return restService.FindUserAsync("http://10.0.2.2:5096/api/{0}", Username, Password);
        }

        public async Task ResetPassword()
        {
            restService.User.Password = "12345";
            string url = "http://10.0.2.2:5096/api/User/";
            url += restService.User._Id;
            await restService.SaveItemAsync(url, restService.User, false);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
