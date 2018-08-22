using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Business : ContentPage
	{
		public Business ()
		{
			InitializeComponent ();

            airpotname.Text = Settings.AirportName;
            arrival.Text = Settings.Arrivalairport;
            NumberOfTravellers.Text = Settings.NumberOfTravellers;
            Departingdate.Text = Settings.FlightDate;
            DepartTime.Text = Settings.FlightDepartTime;
            aircraftname.Text = Settings.Aircraft;
            date.Text = Settings.FlightDate;
            ArrivalTime.Text = Settings.ReturningFlightTime;
        }


        void ShowPopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new BusinessPopupPage());
        }
    }
}