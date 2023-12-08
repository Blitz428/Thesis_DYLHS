using Android.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class ItemDetailsViewModel : INotifyPropertyChanged
    {
        IRestService restService;
        MainPageViewModel main;
        OwnAndFavouritesViewModel own;
        public ItemDetailsViewModel(IRestService service, MainPageViewModel main, OwnAndFavouritesViewModel own)
        {
            restService = service;
            this.main = main;
            this.own = own;
        }

        IItem item = null;
        public IItem Item { get { return item; } set { item = value; NotifyPropertyChanged(); } }

        public void SetItemFromDashbard()
        {
            Item = main.SelectedItem;
            IsDrink = false;
            isConsumed = false;
            haveIngredients = false;
            if (Item is Drink)
            {
                IsDrink = true;
                Ingredients = (Item as Drink).Ingredients;
                foreach (IItem item in main.Consumed)
                {
                    if (item._Id.Equals(Item._Id))
                    {
                        isConsumed = true;
                        break;
                    }
                    else
                    {
                        isConsumed = false;
                    }
                    
                }
                if (Ingredients.Count>0)
                {
                    haveIngredients = true;
                }
              
            }
            else
            {
                IsDrink = false;
            }


        }
        ObservableCollection<string> ingredients = new ObservableCollection<string>();
        public ObservableCollection<string> Ingredients { get { return ingredients; } set { ingredients = value; NotifyPropertyChanged(); } }

        bool haveIngredients = false;
        public bool HaveIngredients { get { return haveIngredients; } set { haveIngredients = value; NotifyPropertyChanged(); } }

        double quantity;
        public double Quantity { get { return quantity; } set { quantity = value; NotifyPropertyChanged(); } }

        bool isDrink =false;
        public bool IsDrink { get { return isDrink; } set { isDrink = value; NotifyPropertyChanged(); } }

        bool isConsumed = false;
        public bool IsConsumed { get { return isConsumed; } set { isConsumed = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string review;
        public string Review { get { return review; } set { review = value; NotifyPropertyChanged(); } }

        int rate;
        public int Rate { get { return rate; } set {  rate = value; NotifyPropertyChanged(); } }

        Models.Rating rating = new Models.Rating();
        public Models.Rating Rating { get {  return rating; } set { rating = value; NotifyPropertyChanged(); } }

        ObservableCollection<Models.Rating> ratinglist = new ObservableCollection<Models.Rating>();
        public ObservableCollection<Models.Rating> RatingList { get { return ratinglist; } set { ratinglist = value; NotifyPropertyChanged(); } }

        public async Task RateAsync()
        {
            if (Item is Drink)
            {
                rating.Created_by = restService.User.Username;
                rating.Review = review;

                rating.Ratings = rate;

                bool rateexists = false;

                RatingList = await restService.RefreshDataAsync<Models.Rating>("http://10.0.2.2:5096/api/Ratings");
                if (RatingList.Count > 0)
                {
                    foreach (Models.Rating rat in RatingList)
                    {
                        if (rat.Created_by.Equals(restService.User.Username))
                        {
                            rateexists = true;
                            string url = "http://10.0.2.2:5096/api/Ratings/";
                            url += rat._Id;
                            await restService.SaveItemAsync(url, Rating, false);
                            (Item as Drink).Ratings.Add(Rating.Created_by + " - " + Rating.Review + " - " + Rating.Ratings);

                            break;
                        }
                    }
                }
                if (rateexists == false)
                {
                    await restService.SaveItemAsync("http://10.0.2.2:5096/api/Ratings", Rating, true);
                    (Item as Drink).Ratings.Add(Rating.Created_by + " - " + Rating.Review + " - " + Rating.Ratings);
                }
                rate = 0;
                review = "";

            }
            

        }

        ObservableCollection<string> itemRatings = new ObservableCollection<string>();
        public ObservableCollection<string> ItemRatings { get { return itemRatings; } set { itemRatings = value; NotifyPropertyChanged(); } }

        public void GetDrinkRatings()
        {
            if (Item is Drink)
            {
                if ((Item as Drink).Ratings.Count > 0)
                {
                    ItemRatings = (Item as Drink).Ratings;
                }
            }


        }
    }
}
