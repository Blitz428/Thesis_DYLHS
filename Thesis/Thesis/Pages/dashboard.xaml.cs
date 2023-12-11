using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thesis.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class dashboard : ContentPage
    {
        public dashboard()
        {
            BindingContext = App.MPViewModel;
            App.MPViewModel.SetUser();

            InitializeComponent();
        }

        async void Reset_Clicked(object sender, EventArgs e)
        {
            App.MPViewModel.Alcohol = 0;
            App.MPViewModel.Kcal =0;
            App.MPViewModel.BAC = 0;
            App.MPViewModel.BACdisplay = "0%";
            App.MPViewModel.Carbon = 0;
            App.MPViewModel.Fat = 0;
            App.MPViewModel.Protein = 0;
            App.MPViewModel.TimeUntilClean = DateTime.Now ;
            App.MPViewModel.SearchResults.Clear();
            App.MPViewModel.Consumed.Clear();
            App.MPViewModel.Progressbarvalue = 0;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartCountDownTimer();
            App.MPViewModel.SetUser();
        }
        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            App.MPViewModel.SearchResults.Clear();
            await App.MPViewModel.GetSearchResult();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            await Navigation.PushAsync(new drink_details());
        }

        async void Info_Clicked(object sender, EventArgs e)
        {
            if (State.Text.Equals("Tiszta tudatállapot"))
            {
                await DisplayAlert("Info", "Ilyen mennyiségben természetesen viselkedik az illető és csak vizsgálatok által mutatható ki a fogyasztás.", "OK");
            }
            else
            if (State.Text.Equals("Elhanyagolható mértékű hatás"))
            {
                await DisplayAlert("Info", "Nehezebbé válik a koncentráció, és az illetőn észrevehető hatások jelentkeznek, mint például a beszédesség, örömérzet, relaxáció és enyhe eufória.", "OK");
            }
            else if (State.Text.Equals("Enyhe ittasság"))
            {
                await DisplayAlert("Info", "Tompulnak az érzések, gátlástalanság és extroverzió áll fent az illetőnél. Az érvelés, megértés és periferikus látás gyengülhet. Enyhe másnaposság jelentkezhet, de a szimptómákat fájdalomcsillapítóval orvosolni lehet.", "OK");

            }
            else if (State.Text.Equals("Mérsékelt ittasság"))
            {
                await DisplayAlert("Info", "Hangulatingadozások, túlzott kifejezések, erős harag vagy szomorúság, erőszakos viselkedés és csökkent libidó tapasztalható. Reflexek és kulcsfontosságú motoros kézségek károsodhatnak és a reakciók lelassulhatnak. Fennáll az ideiglenes alkoholmérgezés esélye.\r\nMérsékelt vagy súlyos másnaposság jelentkezhet, ezért ajánlott fájdalomcsillapító és rendszeres vízfogyasztás.\r\n", "OK");

            }
            else if (State.Text.Equals("Súlyos ittasság"))
            {
                await DisplayAlert("Info", "Viselkedésbeli változások mutatkoznak, beleértve a kábulatot, tompa érzéseket, felfogási kézség elvesztését. Fennáll az eszméletvesztés esélye, súlyos mozgászavarokkal és memóriavesztéssel küzdhet az illető.\r\nSúlyos másnaposság jelentkezhet, így erősen ajánlott fájdalomcsillapító és sok folyadék bevitele, még akkor is, ha az illető ezt nem értékeli.\r\n", "OK");

            }
            else if (State.Text.Equals("Súlyos ittasság"))
            {
                await DisplayAlert("Info", "Központi idegrendszeri funkciók súlyos gátlása, eszméletvesztés, kóma vagy legrosszabb esetben halál kockázata. Kontrollálhatatlan vizelés, légzéskárosodás és teljes egyensúlyvesztés történhet. Szükséges lehet orvosi segítség kérése.", "OK");

            }
            else if (State.Text.Equals("Súlyos ittasság"))
            {
                await DisplayAlert("Info", "Nagy a kockázata az alkohol okozta kómának, eszméletvesztésnek és akár a halálnak is, azonnali orvosi beavatkozás szükséges!", "OK");

            }

        }

        public void StartCountDownTimer()
        {
            if (App.MPViewModel.TimeUntilClean != null)
            {
                timer = new System.Timers.Timer();
                timer.Interval = 1000;
                timer.Elapsed += SecondElapsed;
                TimeSpan ts = App.MPViewModel.TimeUntilClean - DateTime.Now;
                cTimer = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
                timer.Start();
            }

        }
        string cTimer;
        System.Timers.Timer timer;
        void SecondElapsed(object sender, EventArgs e)
        {
            TimeSpan ts = App.MPViewModel.TimeUntilClean - DateTime.Now;


            cTimer = ts.ToString("h':'m':'s' '");

            MainThread.BeginInvokeOnMainThread(() =>
            {

                TimeLabel.Text = cTimer;
               
            });

            if (App.MPViewModel.BAC > 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {

                    App.MPViewModel.BAC -= (0.015 / 3600);
                    App.MPViewModel.Progressbarvalue = App.MPViewModel.BAC / 0.5;


                });


            }

            if (App.MPViewModel.BAC <= 0.03)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Tiszta tudatállapot";
                    State.TextColor = Color.FromHex("#80ff00");
                });

            }
            else
            if (0.03 < App.MPViewModel.BAC && App.MPViewModel.BAC <= 0.05)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Elhanyagolható mértékű hatás";
                    State.TextColor = Color.FromHex("#bfff00");
                });

            }
            else
            if (0.05 < App.MPViewModel.BAC && App.MPViewModel.BAC <= 0.15)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Enyhe ittasság";
                    State.TextColor = Color.FromHex("#ffff00");
                });

            }
            else
            if (0.15 < App.MPViewModel.BAC && App.MPViewModel.BAC <= 0.25)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Mérsékelt ittasság";
                    State.TextColor = Color.FromHex("#ffbf00");
                });

            }
            else
            if (0.25 < App.MPViewModel.BAC && App.MPViewModel.BAC <= 0.3)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Súlyos ittasság";
                    State.TextColor = Color.FromHex("#ff8000");
                });

            }
            else
            if (0.3 < App.MPViewModel.BAC && App.MPViewModel.BAC <= 0.5)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Súlyos alkoholmérgezés";
                    State.TextColor = Color.FromHex("#ff4000");
                });

            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    State.Text = "Halálos alkoholmérgezés";
                    State.TextColor = Color.FromHex("#ff0000");
                });

            }

            if ((ts.TotalMilliseconds < 0) || (ts.TotalMilliseconds < 1000))
            {
                timer.Stop();
            }
        }


    }
}