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
    class SeatSelectionService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET SeatSelection information
        public List<SeatSelectionModel> GetSeatSelections()
        {
            var httpClient = new HttpClient();

            var json =  httpClient.GetStringAsync(rootUrl + "api/SeatSelections").Result;
            var seatSelection = JsonConvert.DeserializeObject<List<SeatSelectionModel>>(json);

            return seatSelection;
        }

        // GET Seat
        /* public async Task<List<SeatSelection>> Getseat()
          {
              var httpClient = new HttpClient();

              var json = await httpClient.GetStringAsync(rootUrl + "api/SeatSelections");
              var seatSelections = JsonConvert.DeserializeObject<List<SeatSelection>>(json);

              Debug.WriteLine(seatSelections);
              return seatSelections;
          }*/

        // GET SeatSelection by ID
        public async Task<SeatSelectionModel> GetSeatSelectionID()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/GetSeatSelection?id=" + Settings.AirportID);
            var seatSelections = JsonConvert.DeserializeObject<SeatSelectionModel>(json);

            Debug.WriteLine(seatSelections);
            return seatSelections;
        }

        // POST SeatSelection
        public async Task AddSeatSelection(SeatSelectionModel seatSelection)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(seatSelection);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/SeatSelections", stringContent);
        }

        // PUT seatSelection
        public async Task UpdateSeatSelection(string id, SeatSelectionModel seatSelection)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(seatSelection);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/SeatSelections/" + id, stringContent);
        }

        // DELETE seatSelection
        public async Task DeleteSeatSelectio(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/SeatSelections/" + id);
        }
    }
}
