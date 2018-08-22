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
    class FlightTravellerDetailsService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET FlightTravellerDetail information
        public async Task<List<FlightTravellerDetail>> GetFlightTravellerDetails()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/FlightTravellerDetails");
            var flightTravellers = JsonConvert.DeserializeObject<List<FlightTravellerDetail>>(json);

            return flightTravellers;
        }

        // GET FlightTravellerDetail by ID
        public async Task<List<FlightTravellerDetail>> GetFlightTravellerDetail()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/GetFlightTravellerDetails?id=" + Settings.CustomerID);
            var flightTravellerDetail = JsonConvert.DeserializeObject<List<FlightTravellerDetail>>(json);

            Debug.WriteLine(flightTravellerDetail);
            return flightTravellerDetail;
        }

        // POST FlightTravellerDetail
        public async Task AddFlightTravellerDetail(FlightTravellerDetail flightTravellerDetail)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightTravellerDetail);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/FlightTravellerDetails", stringContent);
        }

        // PUT FlightTravellerDetail
        public async Task UpdateFlightTravellerDetail(int id, FlightTravellerDetail flightTravellerDetail)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flightTravellerDetail);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/FlightTravellerDetails/" + id, stringContent);
        }

        // DELETE FlightTravellerDetail
        public async Task DeleteFlightTravellerDetail(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/FlightTravellerDetails/" + id);
        }
    }
}
