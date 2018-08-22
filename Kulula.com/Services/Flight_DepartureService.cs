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
    class Flight_DepartureService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET flight_Departure information
        public  List<Flight_Departure> GetFlight_Departures()
        {
            var httpClient = new HttpClient();

            var json = httpClient.GetStringAsync(rootUrl + "api/Flight_Departure").Result;
            var flight_Departures = JsonConvert.DeserializeObject<List<Flight_Departure>>(json);

            return flight_Departures;
        }

        // GET flight_Departure by ID
        public async Task<Flight_Departure> GetFlight_DeparturesID(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/Flight_Departure/" + id);
            var flight_Departure = JsonConvert.DeserializeObject<Flight_Departure>(json);

            Debug.WriteLine(flight_Departure);
            return flight_Departure;
        }

        // POST flight_Departure
        public async Task addflight_Departure(Flight_Departure flight_Departure)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flight_Departure);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/Flight_Departure", stringContent);
        }

        // PUT flight_Departure
        public async Task Updateflight_Departure(int id, Flight_Departure flight_Departure)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(flight_Departure);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/Flight_Departure/" + id, stringContent);
        }

        // DELETE flight_Departure
        public async Task Deleteflight_Departure(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/Flight_Departure/" + id);
        }
    }
}
