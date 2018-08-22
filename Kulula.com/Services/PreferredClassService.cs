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
    class PreferredClassService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET PreferredClass information
        public async Task<List<PreferredClass>> GetPreferredClasses()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/PreferredClasses");
            var preferredClasses = JsonConvert.DeserializeObject<List<PreferredClass>>(json);

            return preferredClasses;
        }

        // GET Seat
        /* public async Task<List<SeatSelection>> Getseat()
          {
              var httpClient = new HttpClient();

              var json = await httpClient.GetStringAsync(rootUrl + "api/SeatSelections" + Settings.CustomerID);
              var seatSelections = JsonConvert.DeserializeObject<List<SeatSelection>>(json);

              Debug.WriteLine(seatSelections);
              return seatSelections;
          }*/

        // GET PreferredClass by ID
        public async Task<PreferredClass> GetPreferredClass()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/GetPreferredClasses?id=" + Settings.AirportID);
            var preferredClass = JsonConvert.DeserializeObject<PreferredClass>(json);

            Debug.WriteLine(preferredClass);
            return preferredClass;
        }

        // POST PreferredClass
        public async Task AddPreferredClass(PreferredClass preferredClass)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(preferredClass);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/PreferredClasses", stringContent);
        }

        // PUT PreferredClass
        public async Task UpdatePreferredClass(int id, PreferredClass preferredClass)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(preferredClass);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/PreferredClasses/" + id, stringContent);
        }

        // DELETE PreferredClass
        public async Task DeletePreferredClass(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/SeatSelections/" + id);
        }
    }
}
