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
    class CartService
    {
        private string rootUrl = "http://192.168.1.203:45455/";


        // POST Cart
        public async Task AddCart(Cart cart)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(cart);
            Debug.WriteLine(json);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(rootUrl + "api/Carts", stringContent);
        }

        // PUT Cart
        public async Task UpdateCart(int id, Cart cart)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(cart);
            StringContent stringContent = new StringContent(json);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(rootUrl + "api/Carts/" + id, stringContent);
        }

        // GET Cart
        public async Task<List<Cart>> GetCart()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/Carts" );
            var cart = JsonConvert.DeserializeObject<List<Cart>>(json);

            return cart;
        }

        public async Task<List<Cart>> GetCartID(int id)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(rootUrl + "api/Carts/" + id);
            var cart = JsonConvert.DeserializeObject<List<Cart>>(json);

            return cart;
        }

        // DELETE Cart
        public async Task DeleteCart(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(rootUrl + "api/Carts/" + id);
        }
    }
}
