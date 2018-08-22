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
    class PaymentService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // POST Payment
        public async Task AddPayment(Payments payment)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(payment);
            Debug.WriteLine(json);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/Payments", stringContent);
        }

        // PUT Payment
        public async Task UpdatePayment(int id, Payments payment)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(payment);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/Payments/" + id, stringContent);
        }

        // GET Payment
        public async Task<List<Payments>> GetPayment()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(rootUrl + "api/Payment?id=" + Settings.CustomerID);
            var payment = JsonConvert.DeserializeObject<List<Payments>>(json);

            return payment;
        }

    }
}
