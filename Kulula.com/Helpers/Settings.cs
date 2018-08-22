using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Kulula.com.Helpers
{
    class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static string CustomerID
        {
            get
            {
                return AppSettings.GetValueOrDefault("CustomerID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("CustomerID", value);
            }
        }
        public static string AirportID
        {
            get
            {
                return AppSettings.GetValueOrDefault("AirportID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AirportID", value);
            }

        }
        public static string AirportName
        {
            get
            {
                return AppSettings.GetValueOrDefault("AirportName", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AirportName", value);
            }

        }

        public static string Arrivalairport
        {
            get
            {
                return AppSettings.GetValueOrDefault("Arrivalairport", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Arrivalairport", value);
            }

        }
        public static string ArrivalID
        {
            get
            {
                return AppSettings.GetValueOrDefault("ArrivalID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("ArrivalID", value);
            }

        }

        public static string Aircraft
        {
            get
            {
                return AppSettings.GetValueOrDefault("Aircraft", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Aircraft", value);
            }
        }

        public static string AircraftID
        {
            get
            {
                return AppSettings.GetValueOrDefault("AircraftID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AircraftID", value);
            }
        }
        public static string TotalCost
        {
            get
            {
                return AppSettings.GetValueOrDefault("TotalCost", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("TotalCost", value);
            }
        }

        public static string CartQuanity
        {
            get
            {
                return AppSettings.GetValueOrDefault("CartQuanity", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("CartQuanity", value);
            }
        }

        public static string FlightDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightDate", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightDate", value);
            }
        }
          public static string ReturningFlightTime
        {
            get
            {
                return AppSettings.GetValueOrDefault("ReturningFlightTime", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("ReturningFlightTime", value);
            }
        }
        public static string NumberOfTravellers
        {
            get
            {
                return AppSettings.GetValueOrDefault("NumberOfTravellers", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("NumberOfTravellers", value);
            }
        }
        public static string FlightDepartTime
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightDepartTime", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightDepartTime", value);
            }
        }
        
       public static string PaymentID
        {
            get
            {
                return AppSettings.GetValueOrDefault("PaymentID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("PaymentID", value);
            }
        }

        public static string Standard
        {
            get
            {
                return AppSettings.GetValueOrDefault("standard", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("standard", value);
            }
        }
        public static string Semiflex
        {
            get
            {
                return AppSettings.GetValueOrDefault("semiflex", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("semiflex", value);
            }
        }
        public static string Fullyflex
        {
            get
            {
                return AppSettings.GetValueOrDefault("fullyflex", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("fullyflex", value);
            }
        }

        public static string Business
        {
            get
            {
                return AppSettings.GetValueOrDefault("Business", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Business", value);
            }
        }

        public static string Date
        {
            get
            {
                return AppSettings.GetValueOrDefault("Date", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Date", value);
            }
        }

        public static string FlightExtras0
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightExtras0", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightExtras0", value);
            }
        }
        public static string FlightExtras1
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightExtras1", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightExtras1", value);
            }
        }
        public static string FlightExtras2
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightExtras2", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightExtras2", value);
            }
        }
        public static string FlightExtrass
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightExtrass", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightExtrass", value);
            }
        }
    }
}
