using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Kulula.com.Helpers;
using Kulula.com.Models;

namespace Kulula.com.Services
{
    class UserService
    {
        private string rootUrl = "http://192.168.1.203:45455/";

        // GET Customers
        public async Task<List<Customer>> GetCustomers()
        {
            var httpClient = new HttpClient();

            var customersJSON = await httpClient.GetStringAsync(rootUrl + "api/Users");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customersJSON);

            return customers;
        }

        // GET Customer Claims
        public Customer GetCustomerClaims()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Settings.AccessToken);
            var response = httpClient.GetStringAsync(rootUrl + "api/GetUserClaims").Result;
            var claims = JsonConvert.DeserializeObject<Customer>(response);

            Debug.WriteLine(claims);
            return claims;
        }

        // POST Customer
        public async Task AddCustomer(Customer customer)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(customer);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/Users", stringContent);
        }

        // PUT Customer
        public async Task UpdateCustomer(int id, Customer customer)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(customer);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/Users/" + id, stringContent);
        }

        // DELETE Customer
        public async Task DeleteCustomer(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/Users/" + id);
        }

        // Authenicate User
        public async Task<string> LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post,
                rootUrl + "/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            // JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var jwtDynamic = JObject.Parse(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");

            return accessToken;
        }
    }
}
