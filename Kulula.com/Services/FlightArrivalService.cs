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
    class FlightArrivalService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET flightArrival information
        public async Task<List<FlightArrival>> GetFlightArrivals()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightArrivals");
            var flightArrivals = JsonConvert.DeserializeObject<List<FlightArrival>>(json);

            return flightArrivals;
        }

        // GET flightArrival by ID
        public async Task<FlightArrival> GetFlightArrivalID(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightArrivals/" + id);
            var flightArrival = JsonConvert.DeserializeObject<FlightArrival>(json);

            Debug.WriteLine(flightArrival);
            return flightArrival;
        }

        // POST flightArrival
        public async Task addflightExtras(FlightArrival flightArrival)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightArrival);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/FlightArrivals", stringContent);
        }

        // PUT flightArrival
        public async Task UpdateflightArrival(int id, FlightArrival flightArrival)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightArrival);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/FlightArrivals/" + id, stringContent);
        }

        // DELETE flightArrival
        public async Task DeleteflightArrival(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/FlightArrivals/" + id);
        }
    }
}
