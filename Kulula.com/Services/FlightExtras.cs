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
    class FlightExtras
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET FlightTravellerDetail information
        public async Task<List<FlightExtra>> GetFlightExtras()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightExtras");
            var flightExtras = JsonConvert.DeserializeObject<List<FlightExtra>>(json);

            return flightExtras;
        }

        // GET FlightTravellerDetail by ID
        public async Task<FlightExtra> GetFlightExtraID(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightExtras/" + id);
            var flightExtrases = JsonConvert.DeserializeObject<FlightExtra>(json);

            Debug.WriteLine(flightExtrases);
            return flightExtrases;
        }

        // POST FlightTravellerDetail
        public async Task addflightExtras(FlightExtra flightExtra)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightExtra);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/FlightExtras", stringContent);
        }

        // PUT FlightTravellerDetail
        public async Task UpdateflightExtras(int id, FlightExtra flightExtra)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightExtra);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/FlightExtras/" + id, stringContent);
        }

        // DELETE FlightTravellerDetail
        public async Task DeleteflightExtras(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/FlightExtras/" + id);
        }
    }
}
