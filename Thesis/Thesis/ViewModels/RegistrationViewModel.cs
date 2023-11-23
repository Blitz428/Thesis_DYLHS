using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;


namespace Thesis.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        IRestService _restService;

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
        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set
            {
                if (value != null)
                {
                    email = value;
                    NotifyPropertyChanged();
                }

            }
        }

        private string role = string.Empty;
        public string Role
        {
            get { return role; }
            set
            {
                if (value != null)
                {
                    role = value;
                    NotifyPropertyChanged();
                }

            }
        }

        private double mobile;
        public double Mobile
        {
            get { return mobile; }
            set
            {
                if (value != null)
                {
                    mobile = value;
                    NotifyPropertyChanged();
                }

            }
        }

        private double points = double.NaN;
        public double Points
        {
            get { return points; }
            set
            {
                if (value != double.NaN)
                {
                    points = value;
                    NotifyPropertyChanged();
                }

            }
        }

        private bool gender;
        public bool Gender
        {
            get { return gender; }
            set
            {

                gender = value;
                NotifyPropertyChanged();


            }
        }

        private double weight = double.NaN;
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value != double.NaN)
                {
                    weight = value;
                    NotifyPropertyChanged();
                }

            }
        }

        private double height = double.NaN;
        public double Height
        {
            get { return height; }
            set
            {
                if (value != double.NaN)
                {
                    height = value;
                    NotifyPropertyChanged();
                }

            }
        }


        private DateTime birthday = DateTime.Today;

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (value != DateTime.Today)
                {
                    birthday = value;
                    NotifyPropertyChanged();
                }
            }

        }


        public RegistrationViewModel(IRestService service)
        {
            _restService = service;
        }

        public Task<bool[]> CheckUserAsync()
        {

            return _restService.CheckUserExistsAsync("http://10.0.2.2:5096/api/{0}", Username, Password, Email, Mobile);

        }

        public Task CreateUserAsync()
        {
            return _restService.CreateUserAsync("http://10.0.2.2:5096/api/{0}", Username, Password, Email, Mobile, Points, Gender, Weight, Height, Birthday);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
