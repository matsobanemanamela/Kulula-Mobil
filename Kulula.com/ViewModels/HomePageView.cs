using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace Kulula.com.ViewModels
{
    class HomePageView : INotifyPropertyChanged
    {
        private Flight_DepartureService Flight_DepartureService = new Flight_DepartureService();
        private FlightArrivalService FlightArrivalService = new FlightArrivalService();

        public Flight_Departure selectedflight_Departure { get; set; }
        public FlightArrival flightArrival { get; set; }

        public List<Flight_Departure> flight_Departures;
      //  public List<FlightArrival> flightArrivals;
       // public List<Flight_Departure> flight_s;

        public List<Flight_Departure> flight_Departureslist
        {
            get { return flight_Departureslist; }
            set
            {
                if (flight_Departures != value)
                {
                    flight_Departures = value;
                    OnPropertyChanged();
                }
            }
        }
      /*  public  HomePageView()
        {
            selectedflight_Departure = new Flight_Departure();
            flightDepartureList();
        }*/

        public Flight_Departure  _Departure
        {
             get { return _Departure; }
            set
            {
                if (_Departure != value)
                {
                    _Departure = value;
                    OnPropertyChanged();
                }
            }


            /* CustomerID.Text = address.CustomerID.ToString();
             RecipientName.Text = address.RecipientName;
             ContactNumber.Text = address.ContactNumber;
             Complex.Text = address.Complex;
             StreetName.Text = address.StreetName;
             Suburb.Text = address.Suburb;
             City.Text = address.City;
             PostalCode.Text = address.PostalCode;*/
        }

     /*   private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }*/
    
   // public event PropertyChangedEventHandler OnPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string airportName = null)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(airportName));
            }
         }       
    }
}
