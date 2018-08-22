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
    class AircraftService
    {
        private string rootUrl = "http://192.168.1.203:45455/";


        // POST Cart
        public async Task AddAircraft(Aircraft aircraft)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(aircraft);
            Debug.WriteLine(json);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/Aircraft", stringContent);
        }

        // PUT Aircraft
        public async Task UpdateAircraft(int id, Aircraft aircraft)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(aircraft);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/Aircraft/" + id, stringContent);
        }
        //get aircrft information

        public async Task<List<Aircraft>> GetAircraft()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/Aircraft");
            var aircrafts = JsonConvert.DeserializeObject<List<Aircraft>>(json);

            return aircrafts;
        }
        // GET aircraftbyID 
        public async Task<List<Aircraft>> GetAircraftid(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/Aircraft/" + id);
            var aircraft = JsonConvert.DeserializeObject<List<Aircraft>>(json);

            return aircraft;
        }

        // DELETE Cart
        public async Task DeleteAircraft(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/Aircraft/" + id);
        }
    }
}
