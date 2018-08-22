using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.ViewModels;
using Kulula.com.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyPopupPage
	{
        private Flight_DepartureService Flight_DepartureService = new Flight_DepartureService();
        private PreferredClassService preferredClass = new PreferredClassService();
        private CartService cartService = new CartService();

        public double priceStandard;
        public double semiflex;
        public double fullyflex;

        double allquantty;
        double semiflexquantity;
        double fullyflexquantity;

        public MyPopupPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            List<PreferredClass> preferredClasses = await preferredClass.GetPreferredClasses();
            PreferredClass preferred = new PreferredClass();

            base.OnAppearing();

            for (int z = 0; z < preferredClasses.Count; z++)
            {

                if (preferredClasses[z].AirportID.ToString() == Settings.AirportID)
                {
                    if (preferredClasses[z].FlightType == "Standard")
                    {

                         Standard.Text = "R" + preferredClasses[z].Price.ToString();

                        Settings.Standard = preferredClasses[z].PreferredClassID.ToString();
                        priceStandard = preferredClasses[z].Price;
                        allquantty = preferredClasses[z].Quantity;
                    }

                }
            }

            for (int z = 0; z < preferredClasses.Count; z++)
            {

                if (preferredClasses[z].AirportID.ToString() == Settings.AirportID)
                {
                    if (preferredClasses[z].FlightType == "Semi-Flexi")
                    {

                         SemiFlexi.Text = "R" + preferredClasses[z].Price.ToString();

                        Settings.Semiflex = preferredClasses[z].PreferredClassID.ToString();

                        semiflex = preferredClasses[z].Price;
                        semiflexquantity = preferredClasses[z].Quantity;
                    }

                }
            }


            for (int z = 0; z < preferredClasses.Count; z++)
            {

                if (preferredClasses[z].AirportID.ToString() == Settings.AirportID)
                {
                    if (preferredClasses[z].FlightType == "Fully Flex")
                    {

                         FullyFlex.Text = "R" + preferredClasses[z].Price.ToString();

                        Settings.Fullyflex = preferredClasses[z].PreferredClassID.ToString();
                        fullyflex = preferredClasses[z].Price;
                        fullyflexquantity = preferredClasses[z].Quantity;
                    }

                }
            }

        }
        private async void Standard_Tocart(object sender, System.EventArgs e) {
            PreferredClass preferred;

            Cart cart;


            cart = new Cart {
                CartID = 0,
                SeatNumber = null,
                PreferredClassID = Convert.ToInt32(Settings.Standard),
                ExtraID = null,
                Totalprice = Convert.ToInt32(Settings.NumberOfTravellers) * priceStandard,
                Quantity = Convert.ToInt32(Settings.NumberOfTravellers)
            };

            await cartService.AddCart(cart);

            preferred = new PreferredClass {

                PreferredClassID = Convert.ToInt32(Settings.Standard),
                AirportID = Convert.ToInt32(Settings.AirportID),
                PreferredClassType = "Economy",
                FlightType = "Standard",
                Price = priceStandard,
                Quantity = allquantty - 1,
                Total = priceStandard * allquantty

            };
            await preferredClass.UpdatePreferredClass(preferred.PreferredClassID, preferred);
            await DisplayAlert("Added to cart", "", "Ok");

            Application.Current.MainPage = new FlightTravellers();
            await PopupNavigation.Instance.PopAsync(true);

        }
        private async void Semiflex_Tocart(object sender, System.EventArgs e)
        {
            PreferredClass preferred;
            Cart cart;


            cart = new Cart
            {
                CartID = 0,
                SeatNumber = null,
                PreferredClassID = Convert.ToInt32(Settings.Semiflex),
                ExtraID = null,
                Totalprice = Convert.ToInt32(Settings.NumberOfTravellers) * semiflex,
                Quantity = Convert.ToInt32(Settings.NumberOfTravellers)
            };

            await cartService.AddCart(cart);

            preferred = new PreferredClass
            {

                PreferredClassID = Convert.ToInt32(Settings.Semiflex),
                AirportID = Convert.ToInt32(Settings.AirportID),
                PreferredClassType = "Economy",
                FlightType = "Semi-Flexi",
                Price = semiflex,
                Quantity = semiflexquantity - 1,
                Total = semiflex * semiflexquantity

            };
            await preferredClass.UpdatePreferredClass(preferred.PreferredClassID, preferred);
            await DisplayAlert("Added to cart", "", "Ok");

            Application.Current.MainPage = new FlightTravellers();
            await PopupNavigation.Instance.PopAsync(true);

        }
        private async void Fullyflex_Tocart(object sender, System.EventArgs e)
        {
            PreferredClass preferred;
            Cart cart;


            cart = new Cart
            {
                CartID = 0,
                SeatNumber = null,
                PreferredClassID = Convert.ToInt32(Settings.Fullyflex),
                ExtraID = null,
                Totalprice = Convert.ToInt32(Settings.NumberOfTravellers) * fullyflex,
                Quantity = Convert.ToInt32(Settings.NumberOfTravellers)
            };

            await cartService.AddCart(cart);

            preferred = new PreferredClass
            {

                PreferredClassID = Convert.ToInt32(Settings.Fullyflex),
                AirportID = Convert.ToInt32(Settings.AirportID),
                PreferredClassType = "Economy",
                FlightType = "Fully Flex",
                Price = fullyflex,
                Quantity = fullyflexquantity - 1,
                Total = fullyflex * fullyflexquantity

            };
            await preferredClass.UpdatePreferredClass(preferred.PreferredClassID, preferred);
            await DisplayAlert("Added to cart", "", "Ok");

            Application.Current.MainPage = new FlightTravellers();
            await PopupNavigation.Instance.PopAsync(true);


        }
    }
}