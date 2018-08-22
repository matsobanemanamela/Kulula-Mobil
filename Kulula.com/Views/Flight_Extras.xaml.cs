using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.ViewModels;
using Kulula.com.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Flight_Extras : ContentPage
	{
        private FlightExtras flightExtraservice = new FlightExtras();
        private CartService cartService = new CartService();
        public Flight_Extras ()
		{
			InitializeComponent ();

            airpotname.Text = Settings.AirportName;
            arrival.Text = Settings.Arrivalairport;
            NumberOfTravellers.Text = Settings.NumberOfTravellers;
            Departingdate.Text = Settings.FlightDate;
        }

        protected override async void OnAppearing()
        {
            List<FlightExtra> flightExtras = await flightExtraservice.GetFlightExtras();
            List<Cart> carts = await cartService.GetCart();
            base.OnAppearing();

            for (int x = 0; x < flightExtras.Count; x++)
            {
                if (flightExtras[x].ExtraID == 1)
                {
                    Flightbagcoverprice.Text = "Price: " + " " + "R" + flightExtras[x].Price.ToString();
                }
            }

            for (int i = 0; i < flightExtras.Count; i++)
            {
                if (flightExtras[i].ExtraID == 2)
                {
                    Extrabagsprice.Text = "Price: " + " " + "R" + flightExtras[i].Price.ToString();
                }
            }

            for (int x = 0; x < flightExtras.Count; x++)
            {
                if (flightExtras[x].ExtraID == 3)
                {
                    slowxsloungeprice.Text = "Price: " + " " + "R" + flightExtras[x].Price.ToString();
                }
            }

            cartview.Text = "R" + carts[0].Totalprice.ToString();
        }

        private async void Flightbagcover(object sender, System.EventArgs e)
        {
            List<FlightExtra> flightExtras = await flightExtraservice.GetFlightExtras();
            List<Cart> carts = await cartService.GetCart();
            Cart cart;
            FlightExtra flightExtra;

            cart = new Cart {
                CartID = carts[0].CartID,
                ExtraID = flightExtras[0].ExtraID,
                PreferredClassID = carts[0].PreferredClassID,
                SeatNumber = null,
                Quantity = carts[0].Quantity,
                Totalprice = carts[0].Quantity * flightExtras[0].Price + carts[0].Totalprice
            };
            await cartService.AddCart(cart);
            await cartService.UpdateCart(cart.CartID, cart);

            flightExtra = new FlightExtra {

                ExtraID = flightExtras[0].ExtraID,
                FlightextraType = flightExtras[0].FlightextraType,
                Price = flightExtras[0].Price,
                Quantity = flightExtras[0].Quantity - 1,
                TotalPrice = flightExtras[0].Quantity *  flightExtras[0].Price 
            };
            
            Settings.FlightExtrass = flightExtras[0].Price.ToString();
            Settings.FlightExtras0 = Settings.FlightExtrass;
            await flightExtraservice.UpdateflightExtras(flightExtra.ExtraID, flightExtra);
            await App.Current.MainPage.DisplayAlert("Added to cart", "", "Ok");

        }

        private async void Extrabags(object sender, System.EventArgs e)
        {
            List<FlightExtra> flightExtras = await flightExtraservice.GetFlightExtras();
            List<Cart> carts = await cartService.GetCart();
            Cart cart;
            FlightExtra flightExtra;
            cart = new Cart
            {
                CartID = carts[0].CartID,
                ExtraID = flightExtras[1].ExtraID,
                PreferredClassID = carts[0].PreferredClassID,
                SeatNumber = null,
                Quantity = carts[0].Quantity,
                Totalprice = carts[0].Quantity * flightExtras[1].Price + carts[0].Totalprice
            };
            await cartService.AddCart(cart);
            await cartService.UpdateCart(cart.CartID, cart);


            flightExtra = new FlightExtra
            {

                ExtraID = flightExtras[1].ExtraID,
                FlightextraType = flightExtras[1].FlightextraType,
                Price = flightExtras[1].Price,
                Quantity = flightExtras[1].Quantity - 1,
                TotalPrice = flightExtras[1].Quantity * flightExtras[1].Price
            };
           Settings.FlightExtras1 = flightExtras[1].Price.ToString();
            Settings.FlightExtras0 = Settings.FlightExtras1 + Settings.FlightExtras0;
            await flightExtraservice.UpdateflightExtras(flightExtra.ExtraID, flightExtra);
            await App.Current.MainPage.DisplayAlert("Added to cart", "", "Ok");
        }


        private async void SLOWXSLounge(object sender, System.EventArgs e)
        {
            List<FlightExtra> flightExtras = await flightExtraservice.GetFlightExtras();
            List<Cart> carts = await cartService.GetCart();
            Cart cart;
            FlightExtra flightExtra;
            cart = new Cart
            {
                CartID = carts[0].CartID,
                ExtraID = flightExtras[2].ExtraID,
                PreferredClassID = carts[0].PreferredClassID,
                SeatNumber = null,
                Quantity = carts[0].Quantity,
                Totalprice = carts[0].Quantity * flightExtras[2].Price + carts[0].Totalprice
            };
            await cartService.AddCart(cart);
            await cartService.UpdateCart(cart.CartID, cart);

            flightExtra = new FlightExtra
            {

                ExtraID = flightExtras[2].ExtraID,
                FlightextraType = flightExtras[2].FlightextraType,
                Price = flightExtras[2].Price,
                Quantity = flightExtras[2].Quantity - 1,
                TotalPrice = flightExtras[2].Quantity * flightExtras[2].Price
            };
            Settings.FlightExtras2 = flightExtras[2].Price.ToString();
            Settings.FlightExtras0 = Settings.FlightExtras2 + Settings.FlightExtras0;
            await flightExtraservice.UpdateflightExtras(flightExtra.ExtraID, flightExtra);

            await App.Current.MainPage.DisplayAlert("Added to cart", "", "Ok");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Payment();
        }
        void ShowPopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Viewcartpopup());
        }
    }
}