using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class FriendsViewModel : INotifyPropertyChanged
    {
        IRestService restService;

        public FriendsViewModel(IRestService service)
        {
            restService = service;
        }

        ObservableCollection<User> friends = new ObservableCollection<User>();
        public ObservableCollection<User> Friends { get { return friends; } set { friends = value; NotifyPropertyChanged(); } }

        ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get { return users; } set { users = value; NotifyPropertyChanged(); } }

        User user = new User();
        public User User { get { return user; } set { user = value; NotifyPropertyChanged(); } }

        ObservableCollection<User> searchResults = new ObservableCollection<User>();
        public ObservableCollection<User> SearchResults { get { return searchResults; } set { searchResults = value; NotifyPropertyChanged(); } }

        string searchInput;
        public string SearchInput { get { return searchInput; } set { searchInput = value; NotifyPropertyChanged(); } }

        public async Task<ObservableCollection<User>> GetFriends()
        {
            User = restService.User;
            Users = await restService.RefreshDataAsync<User>("http://10.0.2.2:5096/api/Users");

            foreach (string id in User.Friends)
            {
                foreach (User user in Users)
                {
                    if (user._Id.Equals(id))
                    {
                        if (!Friends.Contains(user))
                        {
                            Friends.Add(user);
                        }

                    }
                }
            }
            return Friends;
        }

        public async Task<ObservableCollection<User>> GetSearchResult()
        {

            Users = await restService.RefreshDataAsync<User>("http://10.0.2.2:5096/api/Users");
            foreach (User user in Users)
            {
                if (user.Username.Contains(SearchInput))
                {
                    if (!SearchResults.Contains(user))
                    {
                        SearchResults.Add(user);
                    }

                }
            }
            return SearchResults;
        }

        public async Task AddFriend(User userToFriend)
        {
            User.Friends.Add(userToFriend._Id);
            await restService.SaveItemAsync("http://10.0.2.2:5096/api/Users", User, false);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
