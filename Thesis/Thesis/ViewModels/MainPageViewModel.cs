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
        User user = null;
        public User User
        {
            get { return user; }
            set
            {
                if (_restService.User !=null)
                {
                    user = _restService.User;
                }
            } }

        int level;
        public int Level { get { return level; } set {
                if (user.Points!=double.NaN)
                {
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
