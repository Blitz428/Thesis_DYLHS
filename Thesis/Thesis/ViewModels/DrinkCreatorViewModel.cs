using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis.ViewModels
{
    public class DrinkCreatorViewModel : INotifyPropertyChanged
    {
        IRestService restService;

        public DrinkCreatorViewModel(IRestService service)
        {
                restService = service;
        }

        Drink drink;
        public Drink DrinkToSave { get { return drink; } set { drink = value;  } }

        User user;
        public User CurrentUser { get; set; }
        public string Created_by { get; set; }


 
        public string Drink_name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public double Alcohol { get; set; }

        public double Kcal { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Carbon { get; set; }

        public double Avg_rating { get; set; }

        public bool Verified { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public async Task CreateDrinkAsync()
        {
            DrinkToSave = new Drink();
            CurrentUser = restService.User;

            DrinkToSave.Created_by = CurrentUser._Id;
            DrinkToSave.Drink_name = Drink_name;
            DrinkToSave.Description=Description;
            DrinkToSave.Type = Type;
            DrinkToSave.Alcohol = Alcohol;
            DrinkToSave.Kcal = Kcal;
            DrinkToSave.Fat = Fat;
            DrinkToSave.Protein = Protein;
            DrinkToSave.Carbon = Carbon;
            DrinkToSave.Avg_rating = Avg_rating;
            if (CurrentUser.Role.Equals("admin"))
            {
                DrinkToSave.Verified = true;
            }
            else
            {
                DrinkToSave.Verified = false;
            }

            DrinkToSave.Ingredients = new List<string>() { };
            DrinkToSave.Ratings = new List<string>();

   
            await restService.SaveItemAsync<Drink>("http://10.0.2.2:5096/api/Drinks",DrinkToSave,true);
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
