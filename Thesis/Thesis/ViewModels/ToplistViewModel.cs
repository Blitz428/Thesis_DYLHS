using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class ToplistViewModel : INotifyPropertyChanged
    {
        IRestService restService;

        public ToplistViewModel(IRestService service)
        {
            restService = service;
        }

        User currentUser;
        public User CurrentUser { get { return currentUser; } set { currentUser = value; NotifyPropertyChanged(); } }

        ObservableCollection<User> topUsers = new ObservableCollection<User>();
        public ObservableCollection<User> TopUsers { get { return topUsers; } set { topUsers = value; NotifyPropertyChanged(); } }

        ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get { return users; } set { users = value; NotifyPropertyChanged(); } }

        public async Task<ObservableCollection<User>> GetTopUsers()
        {
            Users = await restService.RefreshDataAsync<User>("http://10.0.2.2:5096/api/Users");
            TopUsers = new ObservableCollection<User>(Users.OrderByDescending(o => o.Points).ToList());

            return TopUsers;

        }

        public void GetUser()
        {
            CurrentUser = restService.User;


        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
