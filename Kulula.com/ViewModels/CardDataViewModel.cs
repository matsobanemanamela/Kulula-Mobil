using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.ViewModels;
using Kulula.com.Views;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.ViewModels
{
    class CardDataViewModel
    {
        public IList<Flight_Departure> flight_Departures { get; set; }
        public IList<FlightArrival> flightArrivals { get; set; }
        public IList<FlightBooking> flightBookings { get; set; }

        public object selectedItem { get; set; }

        public CardDataViewModel() {
            flight_Departures = new List<Flight_Departure>();
            flightArrivals = new List<FlightArrival>();
            flightBookings = new List<FlightBooking>();
            GenerateCardModel();
        }
        private void GenerateCardModel() {

            flight_Departures = new ObservableCollection<Flight_Departure>
            {
                new Flight_Departure{

                    AirportName = Settings.AirportID,
                    DepartingDate = Settings.FlightDate,
                    
                }
            };
            flightArrivals = new ObservableCollection<FlightArrival>
            {
                new FlightArrival
                {
                    AirportName = Settings.ArrivalID
                }
            };
            flightBookings = new ObservableCollection<FlightBooking>
            {
                new FlightBooking{

                    NumberOfTravellers =Convert.ToInt32(Settings.NumberOfTravellers),
                    ReturningDate = Settings.ReturningFlightTime
                }

            };


        }
    }
}
