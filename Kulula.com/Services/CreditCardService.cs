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
    class CreditCardService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // POST CreditCard
        public async Task AddCreditCards(CreditCard creditCard)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(creditCard);
            Debug.WriteLine(json);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/CreditCards", stringContent);
        }

        // PUT InternetPaymentSID
        public async Task UpdateCreditCardsD(int id, CreditCard creditCard)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(creditCard);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/CreditCards/" + id, stringContent);
        }

        // GET InternetPaymentSID
        public async Task<List<CreditCard>> GetCreditCardsByID(int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(rootUrl + "api/CreditCards/" + id);
            var creditCards = JsonConvert.DeserializeObject<List<CreditCard>>(json);

            return creditCards;
        }
        
        //Get By Payment ID
        public async Task<List<CreditCard>> GetCreditCards()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(rootUrl + "api/CreditCard?id=" + Settings.PaymentID);
            var creditCards = JsonConvert.DeserializeObject<List<CreditCard>>(json);

            return creditCards;
        }
    }
}
