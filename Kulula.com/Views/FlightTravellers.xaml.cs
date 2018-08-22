using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.ViewModels;
using Kulula.com.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlightTravellers : ContentPage
	{
        private FlightTravellerDetailsService flightTravellerService = new FlightTravellerDetailsService();
        private FlightTravellerDetail flightTraveller;
        private CartService cartService = new CartService();

        public FlightTravellers ()
		{
           
            InitializeComponent ();

            airpotname.Text = Settings.AirportName;
            arrival.Text = Settings.Arrivalairport;
            NumberOfTravellers.Text = Settings.NumberOfTravellers;
            Departingdate.Text = Settings.FlightDate;
            
        }
        protected override async void OnAppearing()
        {
            List<Cart> carts = await cartService.GetCart();
            base.OnAppearing();
            cartview.Text = "R" + carts[0].Totalprice.ToString();
        }
            private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dates = e.NewDate.ToString();
            var t1 = dates.Remove(10);
            Settings.Date = t1;
        }

        private async void Submit(object sender, System.EventArgs e) {
           
            flightTraveller = new FlightTravellerDetail
            {

                TravellerID = 0,
                CustomerID = Convert.ToInt32(Settings.CustomerID),
                SeatNumber = null,
                Firstname = FirstName.Text,
                Lastname = LastName.Text,
                Dateofbirth = Settings.Date,
                Gender = Gender.Text,
                Mobilenumber = MobileNumber.Text,
                Email = Email.Text

            };

            await flightTravellerService.AddFlightTravellerDetail(flightTraveller);
            await DisplayAlert("Sucessfully save", "", "Ok");

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SeatSelection();
        }
        void ShowPopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Viewcartpopup());
        }
    }
}