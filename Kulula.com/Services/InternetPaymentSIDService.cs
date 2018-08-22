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
    class InternetPaymentSIDService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // POST InternetPaymentSID
        public async Task AddInternetPaymentSID(InternetPaymentSID internetPaymentSID)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(internetPaymentSID);
            Debug.WriteLine(json);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/InternetPaymentSIDs", stringContent);
        }

        // PUT InternetPaymentSID
        public async Task UpdateInternetPaymentSID(int id, InternetPaymentSID internetPaymentSID)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(internetPaymentSID);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/InternetPaymentSIDs/" + id, stringContent);
        }

        // GET InternetPaymentSID
        public async Task<List<InternetPaymentSID>> GetInternetPaymentSIDs(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(rootUrl + "api/InternetPaymentSIDs/" + id);
            var internetPayments = JsonConvert.DeserializeObject<List<InternetPaymentSID>>(json);

            return internetPayments;
        }

        //Get By payment ID

        public async Task<List<InternetPaymentSID>> GetInternetPaymentSIDsIDP()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(rootUrl + "api/internetPaymentSID?id=" + Settings.PaymentID);
            var internetPayments = JsonConvert.DeserializeObject<List<InternetPaymentSID>>(json);

            return internetPayments;
        }
    }
}
