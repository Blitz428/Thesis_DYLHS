using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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

        List<User> friends;
        public List<User> Friends { get { return friends; } set { friends = value; NotifyPropertyChanged(); } }

        List<User> users;
        public List<User> Users { get {  return users; } set { users = value; NotifyPropertyChanged(); } }

        User user;
        public User User { get { return user; } set {  user = value; NotifyPropertyChanged(); } }

        List<User> searchResults;
        public List<User> SearchResults { get {  return searchResults; } set {  searchResults = value; NotifyPropertyChanged(); } }

        string searchInput;
        public string SearchInput { get {  return searchInput; } set { searchInput = value; NotifyPropertyChanged(); } }    

        public async Task<List<User>>GetFriends()
        {
            Users = new List<User>();
            Friends = new List<User>();
            Users= await restService.RefreshDataAsync<User>("http://10.0.2.2:5096/api/Users");

            foreach (string id in User.Friends)
            {
                foreach (User user in Users)
                {
                    if (user._Id.Equals(id))
                    {
                        Friends.Add(user);
                    }
                }
            }
            return Friends;
        }


        public async Task<List<User>> GetSearchResult()
        {
            Users = new List<User>();
            SearchResults = new List<User>();
            
            Users = await restService.RefreshDataAsync<User>("http://10.0.2.2:5096/api/Users");
            foreach (User user in Users)
            {
                if (user.Username.Contains(SearchInput))
                {
                    SearchResults.Add(user);
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
