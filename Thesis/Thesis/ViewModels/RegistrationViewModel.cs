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

        private string username;
        public string Username
        {
            get { return username; }
            set
            {

                username = value;
                NotifyPropertyChanged();


            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {

                password = value;
                NotifyPropertyChanged();


            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {

                email = value;
                NotifyPropertyChanged();


            }
        }

        private string role;
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyPropertyChanged();

            }
        }

        private double mobile;
        public double Mobile
        {
            get { return mobile; }
            set
            {

                mobile = value;
                NotifyPropertyChanged();


            }
        }

        private double points;
        public double Points
        {
            get { return points; }
            set
            {

                points = value;
                NotifyPropertyChanged();


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

        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {

                weight = value;
                NotifyPropertyChanged();


            }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set
            {

                height = value;
                NotifyPropertyChanged();


            }
        }


        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {

                birthday = value;
                NotifyPropertyChanged();

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
