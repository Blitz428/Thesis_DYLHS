using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
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

            }
        }

        bool editable = false;
        public bool Editable { get { return editable; } set { editable = value; NotifyPropertyChanged(); } }

        public void GetUser()
        {
            User = _restService.User;
        }
        public void SetEditable()
        {
            if (Editable == false)
            {
                Editable = true;
            }
            else
            {
                Editable = false;
            }

        }
        string url = "http://10.0.2.2:5096/api/Users/";
        public Task EditUserAsync()
        {
            url += User._Id;
            return _restService.SaveItemAsync<User>(url, User, false);

        }
        public async Task DeleteUser()
        {
            url += User._Id;
            await _restService.DeleteItemAsync(url, User._Id);
        }

        public ProfileViewModel(IRestService restService)
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
