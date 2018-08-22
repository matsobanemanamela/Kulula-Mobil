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
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPage : ContentPage
    {
        private CartService cartService = new CartService();
        private FlightTravellerDetailsService detailsService = new FlightTravellerDetailsService();
        private PaymentService paymentService = new PaymentService();
        private PreferredClassService preferredClass = new PreferredClassService();

        public ConfirmationPage()
        {

            InitializeComponent();


        }
        protected override async void OnAppearing()
        {
            List<FlightTravellerDetail> flightTravellers = await detailsService.GetFlightTravellerDetail();
            List<Cart> carts = await cartService.GetCart();
            List<Payments> payments = await paymentService.GetPayment();
            List<FlightTravellerDetail> travellerDetails = new List<FlightTravellerDetail>();
            List<PreferredClass> preferredClasses = await preferredClass.GetPreferredClasses();
            PreferredClass preferred = new PreferredClass();
            //  FlightTravellerDetail flightTravellerDetail;
            base.OnAppearing();
            Thanks.Text = "Thank you for choosing to fly with us! Your flight to " + Settings.Arrivalairport + " is booked. A summary of your flight information is below.";
            flightconfirmation.Text = Settings.UserName + " flight confirmation Total Money Paid " + "R" + carts[0].Totalprice;
            date.Text = Settings.FlightDate;
            DepartTime.Text = Settings.FlightDepartTime;
            aircraftname.Text = Settings.Aircraft;
            ArrivalTime.Text = Settings.ReturningFlightTime;
            airpotname.Text = Settings.AirportName;
            arrival.Text = Settings.Arrivalairport;
            Credit.Text = payments[1].PaymentType;

            for (int z = 0; z < preferredClasses.Count; z++)
            {

                if (preferredClasses[z].PreferredClassID == carts[0].PreferredClassID)
                {

                    Fares.Text = "R" + preferredClasses[z].Price.ToString();
                }
            }

            TotalAmount.Text = "R" + carts[0].Totalprice.ToString();
            /*  for (int x = 0; x < flightTravellers.Count; x++) {

                  flightTravellerDetail = new FlightTravellerDetail {
                      Firstname = flightTravellers[x].Firstname,
                      Lastname = flightTravellers[x].Lastname
              };
                  travellerDetails.Add(flightTravellerDetail);

              }

              flight_Departuresd.ItemsSource = travellerDetails; */
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<Cart> carts = await cartService.GetCart();

            for (int i = 0; i < carts.Count; i++)
            {

                await cartService.DeleteCart(carts[i].CartID);
            }

            Settings.AccessToken = " ";
            Settings.Aircraft = " ";
            Settings.UserName = " ";
            Settings.Password = " ";
            Settings.FlightDate = " ";
            Settings.FlightDepartTime = " ";
            Settings.Aircraft = " ";
            Settings.ReturningFlightTime = " ";
            Settings.AirportName = " ";
            Settings.Arrivalairport = " ";
            Settings.CustomerID = " ";
            Settings.CartQuanity = " ";
            Settings.FlightExtras0 = " ";
            Settings.FlightExtras1 = " ";
            Settings.FlightExtras2 = " ";
            Settings.FlightExtrass = " ";
            Settings.ArrivalID = " ";
            Settings.Business = " ";
            Settings.AirportID = " ";
            Settings.Date = " ";
            Settings.Fullyflex = " ";
            Settings.Standard = " ";
            Settings.Semiflex = " ";
            Settings.TotalCost = " ";
            Settings.PaymentID = " ";
            Settings.AircraftID = " ";
            

             Application.Current.MainPage = new MainPage();
          // await Navigation.PushAsync(new MainPage());

        }
    }
}