using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

            }
        }

        int level;
        public int Level
        {
            get { return level; }
            set
            {
                if (user.Points == 0)
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


        public void SetUser()
        {
            User = _restService.User;
            Level = this.Level;
        }

        ObservableCollection<IItem> items = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> Items { get { return items; } set { items = value; NotifyPropertyChanged(); } }

        public async Task<ObservableCollection<IItem>> GetAllItems()
        {
            ObservableCollection<Drink> drinks = new ObservableCollection<Drink>();
            drinks = await _restService.RefreshDataAsync<Drink>("http://10.0.2.2:5096/api/Drinks");
            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
            ingredients = await _restService.RefreshDataAsync<Ingredient>("http://10.0.2.2:5096/api/Ingredients");

            Items = new ObservableCollection<IItem>();


            foreach (IItem item in drinks)
            {
                if (!Items.Contains(item))
                {
                    Items.Add(item);
                }
            }
            foreach (IItem item in ingredients)
            {
                if (!Items.Contains(item))
                {
                    Items.Add(item);
                }

            }

            return Items;
        }

        string searchInput;
        public string SearchInput { get { return searchInput; } 
            set { searchInput = value; NotifyPropertyChanged(); } }

        ObservableCollection<IItem> searchResults = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> SearchResults { get { return searchResults; } 
            set { searchResults = value; NotifyPropertyChanged(); } }

        public async Task<ObservableCollection<IItem>> GetSearchResult()
        {
            await GetAllItems();

            foreach (IItem item in Items)
            {
                if (item.Name.Contains(SearchInput))
                {
                    if (!SearchResults.Contains(item))
                    {
                        SearchResults.Add(item);
                    }
                }
            }
            return SearchResults;
        }

        IItem selectedItem;
        public IItem SelectedItem { get { return selectedItem; }
            set { selectedItem = value; NotifyPropertyChanged(); } }

        ObservableCollection<IItem> consumed = new ObservableCollection<IItem>();
        public ObservableCollection<IItem> Consumed { get { return consumed; } 
            set { consumed = value; NotifyPropertyChanged(); } }
        IItem itemtoadd;
        public async void ConsumeItem(double quantity)
        {
            if (itemtoadd is Drink)
            {
                itemtoadd = new Drink();
                if ((selectedItem as Drink).Ingredients.Count>0)
                {
                    (itemtoadd as Drink).Ingredients=(selectedItem as Drink).Ingredients;
                }
            }
            else
            {
                itemtoadd = new Ingredient();
            }
            itemtoadd.Alcohol = selectedItem.Alcohol * quantity / 100;
            itemtoadd.Kcal = selectedItem.Kcal * quantity / 100;
            itemtoadd.Protein = selectedItem.Protein * quantity / 100;
            itemtoadd.Fat = selectedItem.Fat * quantity / 100;
            itemtoadd.Carbon = selectedItem.Carbon * quantity / 100;
            itemtoadd.Name = selectedItem.Name +" "+ quantity + "g/ml";
            itemtoadd.Description = selectedItem.Description;
            itemtoadd._Id = selectedItem._Id;

            consumed.Add(itemtoadd);
            User.Points += 10;

            string url = "http://10.0.2.2:5096/api/Users/";
            url += User._Id;
            await _restService.SaveItemAsync<User>(url, User, false);
            CalculateConsumption();

        }

        double alcohol;
        public double Alcohol { get { return alcohol; } set { alcohol = value; NotifyPropertyChanged(); } }

        double kcal;
        public double Kcal { get { return kcal; } set { kcal = value; NotifyPropertyChanged(); } }

        double protein;
        public double Protein { get { return protein; } set { protein = value; NotifyPropertyChanged(); } }

        double fat;
        public double Fat
        {
            get { return fat; }
            set { fat = value; NotifyPropertyChanged(); }
        }
        double carbon;
        public double Carbon { get { return carbon; } set { carbon = value; NotifyPropertyChanged(); } }

        double bac;
        public double BAC { get { return bac; } set { bac = value; NotifyPropertyChanged(); } }

        string bacDisplay;
        public string BACdisplay { get { return bacDisplay; } set { bacDisplay = value; NotifyPropertyChanged(); } }

        DateTime timeUntilClean;
        public DateTime TimeUntilClean { get { return timeUntilClean; } set { timeUntilClean = value; NotifyPropertyChanged(); } }

        double progressbarvalue;
        public double Progressbarvalue { get { return progressbarvalue; } set { progressbarvalue = value; NotifyPropertyChanged(); } }



        public void CalculateConsumption()
        {
            double A = 0;
            double r = 0;
            double t = 0;
            Alcohol = 0;
            Kcal = 0;
            Protein = 0;
            Fat = 0;
            Carbon = 0;
            Progressbarvalue = 0;

            foreach (IItem item in consumed)
            {
                Alcohol += item.Alcohol;
                Kcal += item.Kcal;
                Protein += item.Protein;
                Fat += item.Fat;
                Carbon += item.Carbon;

                A += item.Alcohol * 0.8;

            }
            if (User.Body_data.Gender == false)
            {
                r = 0.68;
            }
            else
            {
                r = 0.55;
            }
            double W = User.Body_data.Weight * 1000;

            BAC = (A / (r * W)) * 100;
            t = BAC / 0.015 * 60 * 60;
            TimeUntilClean = DateTime.Now.AddSeconds(t);
            BACdisplay = string.Concat(Math.Round(BAC, 3).ToString(), "%");
            Progressbarvalue = Math.Round(BAC / 0.5, 1);
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
