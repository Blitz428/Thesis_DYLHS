using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        IRestService _restService;
        User user;
        public User User
        {
            get { return user; }
            set
            {
                
                    user = _restService.User;
                    NotifyPropertyChanged();
                
            } }

        int level;
        public int Level { get { return level; } set {
                if (user.Points!=double.NaN)
                {
                    if (user.Points==0)
                    {
                        level = 0;

                    }
                    if (user.Points < 100)
                    { level = 1; }
                    else if (100 < user.Points && user.Points < 200)
                    {
                        level = 2;
                    }
                    else
                    {
                        level = 3;
                    }
                    NotifyPropertyChanged();
                }
            }
        }
                
        public void SetUser()
        {
            User=_restService.User;
        }        
                
        

        public MainPageViewModel(IRestService restService)
        {
            _restService = restService;
            User = _restService.User;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
