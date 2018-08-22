using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Kulula.com.Helpers;
using Kulula.com.Models;


namespace Kulula.com.Services
{
    class FlightBookingService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET FlightBooking information
        public async Task<List<FlightBooking>> GetFlightBookings()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightBookings");
            var flightBookings = JsonConvert.DeserializeObject<List<FlightBooking>>(json);

            return flightBookings;
        }

        // GET FlightBooking by ID
        public async Task<FlightBooking> GetFlightBooking(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightBookings/" + id);
            var flightBooking = JsonConvert.DeserializeObject<FlightBooking>(json);

            Debug.WriteLine(flightBooking);
            return flightBooking;
        }

        // POST FlightBooking
        public async Task addflightBooking(FlightBooking flightBooking)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightBooking);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/FlightBookings", stringContent);
        }

        // PUT FlightBooking
        public async Task UpdateflightBookings(int id, FlightBooking flightBooking)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightBooking);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/FlightBookings/" + id, stringContent);
        }

        // DELETE FlightBooking
        public async Task DeleteflightBooking(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/FlightBookings/" + id);
        }
    }
}
