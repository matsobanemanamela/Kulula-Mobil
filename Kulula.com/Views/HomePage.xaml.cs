using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulula.com.ViewModels;
using Kulula.com.Services;
using Kulula.com.Models;
using Kulula.com.Helpers;
using Kulula.com.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : TabbedPage
	{

        private Flight_DepartureService Flight_DepartureService = new Flight_DepartureService();
        private FlightArrivalService FlightArrivalService = new FlightArrivalService();
        private AircraftService aircraftService = new AircraftService();

      /*  public Flight_Departure flight_Departure;
        public FlightArrival flightArrival;*/

        public HomePage ()
		{
            var VM = new datepicker();
          
            InitializeComponent();
            BindingContext = VM;
            // AirportId.Text = Settings.AirportID;
       
        }

        /*private List<Flight_Departure> getflights() {

            var db = Flight_DepartureService.GetFlight_Departures();
            return db;

        }*/
         protected override async void OnAppearing()
          {
              base.OnAppearing();

          List<Flight_Departure>flight_Departures = Flight_DepartureService.GetFlight_Departures();
              List<FlightArrival> flightarrivalse = await FlightArrivalService.GetFlightArrivals();
            List<Aircraft> aircraft = await aircraftService.GetAircraft();
          List<FlightArrival> flightArrival = new List<FlightArrival>();
              FlightArrival flightarrival = new FlightArrival() ;
            Aircraft aircrafts = new Aircraft();
             // FlightArrival flightarrivals;
              List<Flight_Departure> flight_Departure = new List<Flight_Departure>();
              Flight_Departure Departures ;
        

            List<string> preferredClasses = new List<string>();

            PreferredClass preferred = new PreferredClass();
          for (int x = 0; x < flight_Departures.Count; x++)
              {
                  Departures = new Flight_Departure
                  {
                      AirportID = flight_Departures[x].AirportID,
                      AircraftID = flight_Departures[x].AircraftID,
                      ArrivalID = flight_Departures[x].ArrivalID,
                      AirportName = flight_Departures[x].AirportName,
                      DepartingDate = flight_Departures[x].DepartingDate,
                      DepartingTime = flight_Departures[x].DepartingTime

                  };
 
                /*   if (flightarrivalse[x].ArrivalID == flight_Departures[x].ArrivalID) {

                             return flightarrivalse[x].AirportName;
                         }*/
                flight_Departure.Add(Departures);
              }

            for (int i = 0; i < flight_Departures.Count; i++)
            {

                if (flight_Departures[i].AirportName == Settings.AirportName)
                {
              
                    var make = flight_Departures[i].ArrivalID.ToString();
                    Settings.ArrivalID = make;

                }
            }

            for (int z = 0; z < flightarrivalse.Count; z++) {
               
                if (flightarrivalse[z].ArrivalID.ToString() == Settings.ArrivalID)
                {
               
                    flightarrival.AirportName = flightarrivalse[z].AirportName;

                   
                }
            
        }

            for (int i = 0; i < flight_Departures.Count; i++)
            {

                if (flight_Departures[i].AirportName == Settings.AirportName)
                {

                    var make = flight_Departures[i].ArrivalID.ToString();
                    Settings.ArrivalID = make;

                }
            }


            for (int z = 0; z < flightarrivalse.Count; z++)
            {

                if (flightarrivalse[z].ArrivalID.ToString() == Settings.ArrivalID)
                {

                    flightarrival.ArrivalTime = flightarrivalse[z].ArrivalTime;


                }

            }


            for (int i = 0; i < flight_Departures.Count; i++)
            {

                if (flight_Departures[i].AirportName == Settings.AirportName)
                {

                    var aicr = flight_Departures[i].AircraftID.ToString();
                    Settings.AircraftID = aicr;

                }
            }

            for (int z = 0; z < aircraft.Count; z++)
            {

                if (aircraft[z].AircraftID.ToString() == Settings.ArrivalID)
                {

                    aircrafts.AircraftName = aircraft[z].AircraftName;


                }

            }
            flightArrival.Add(flightarrival);

            Settings.Arrivalairport = flightarrival.AirportName;
            Settings.Aircraft = aircrafts.AircraftName;
            Settings.ReturningFlightTime = flightarrival.ArrivalTime;

            Picker picker;
              picker = new Picker();
              picker.Title = "select your airport";
              picker.ItemsSource = flight_Departure;


            flight_Departuresd.ItemsSource = flight_Departure;

            flightarrivals.ItemsSource = flightArrival;
            // flight_Departuresds.ItemsSource = flight_Departure;

            preferredClasses.Add("EconomyClass");
            preferredClasses.Add("BusinessClass");

            PreferredClasss.ItemsSource = preferredClasses;

           

         //   Settings.FlightDate = txtDate.Text;
        }

        /* private void Selected_Index(object sender, EventArgs e)
         {
             var flight = flight_Departuresd.Items[flight_Departuresd.SelectedIndex];
             Settings.AirportID = flight;

         }*/
     /*   public void flightID(object sender, EventArgs e) {
            List<Flight_Departure> flight_Departures = Flight_DepartureService.GetFlight_Departures();
           // List<FlightArrival> flightarrivalse = await  FlightArrivalService.GetFlightArrivals();
            List<FlightArrival> flightArrival = new List<FlightArrival>();
            FlightArrival flightarrival = new FlightArrival();
            // FlightArrival flightarrivals;
            List<Flight_Departure> flight_Departure = new List<Flight_Departure>();
            Flight_Departure Departures;

            for (int x = 0; x < flight_Departures.Count; x++) {

                if (flight_Departures[x].AirportName == Settings.AirportID) {

                    var make = flight_Departures[x].ArrivalID;
                  Settings.ArrivalID = make.ToString();

                 

                }
            }
     
        }*/

        private void Search(object sender, EventArgs e)
        {
            List<Flight_Departure> flight_Departures = Flight_DepartureService.GetFlight_Departures();
            List<Flight_Departure> flight_Departure = new List<Flight_Departure>();
            Flight_Departure Departures;
            // Debug.WriteLine(flightID);

            string numberoftravellers = AgeEntry.Text;

            Settings.NumberOfTravellers = numberoftravellers;

            for (int i = 0; i < flight_Departures.Count; i++)
            {

                if (flight_Departures[i].AirportName == Settings.AirportName)
                {

                    var make = flight_Departures[i].DepartingDate;
                    Settings.FlightDate = make;

                }
            }

            for (int i = 0; i < flight_Departures.Count; i++)
            {
                if (flight_Departures[i].AirportName == Settings.AirportName)
                {
                    var ID = flight_Departures[i].AirportID.ToString();
                    Settings.AirportID = ID;
                }

            }

            for (int i = 0; i < flight_Departures.Count; i++)
            {

                if (flight_Departures[i].AirportName == Settings.AirportName)
                {

                    var time = flight_Departures[i].DepartingTime;
                    Settings.FlightDepartTime = time;

                }
            }

            if (txtDate.Text == Settings.FlightDate)
            {
                if (PreferredClasss.Items[PreferredClasss.SelectedIndex] == "BusinessClass")
                {
                    Application.Current.MainPage = new Business();
                }
                else if (PreferredClasss.Items[PreferredClasss.SelectedIndex] == "EconomyClass")
                {
                    Application.Current.MainPage = new Economy();

                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Please incorrect date", " ", "OK");
            }
        }

        private void flight_Departuresd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var flight = flight_Departuresd.Items[flight_Departuresd.SelectedIndex];
            Settings.AirportName = flight;
        }

        private void PreferredClasss_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dates = e.NewDate.ToString();

            
            var t1 = dates.Remove(10);
            var spl = t1.Split('/');
            string date = spl[0] + "-" + spl[1] + "-" + spl[2];
            txtDate.Text = date;
            Settings.FlightDate = txtDate.Text;
        }

        private async void logout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        }
 

}