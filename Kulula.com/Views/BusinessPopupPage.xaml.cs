using Rg.Plugins.Popup.Services;
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
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BusinessPopupPage
	{
        private Flight_DepartureService Flight_DepartureService = new Flight_DepartureService();
        private PreferredClassService preferredClass = new PreferredClassService();
        private CartService cartService = new CartService();
        public double businessprice;

        double allquantty;

        public BusinessPopupPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            List<PreferredClass> preferredClasses = await preferredClass.GetPreferredClasses();
            PreferredClass preferred = new PreferredClass();

            base.OnAppearing();

            for (int z = 0; z < preferredClasses.Count; z++) {

                if (preferredClasses[z].AirportID.ToString() == Settings.AirportID) {
                    if (preferredClasses[z].FlightType == "Business") {

                        business.Text = "R" + preferredClasses[z].Price.ToString();

                        Settings.Business = preferredClasses[z].PreferredClassID.ToString();
                        businessprice = preferredClasses[z].Price;

                        allquantty = preferredClasses[z].Quantity;
                    }

                }
            }
         
        }


        

       private async void Handle_clicked(object sender, System.EventArgs e)
        {
            PreferredClass preferredClasses;
            Cart cart;


            cart = new Cart
            {
                CartID = 0,
                SeatNumber = null,
                PreferredClassID = Convert.ToInt32(Settings.Business),
                ExtraID = null,
                Totalprice = Convert.ToInt32(Settings.NumberOfTravellers) * businessprice,
                Quantity = Convert.ToInt32(Settings.NumberOfTravellers)
            };

           await cartService.AddCart(cart);

            preferredClasses = new PreferredClass {

                PreferredClassID = Convert.ToInt32(Settings.Business),
                AirportID = Convert.ToInt32(Settings.AirportID),
                PreferredClassType = "Business",
                FlightType = "Business",
                Price = businessprice,
                Quantity = allquantty - 1,
                Total = businessprice * allquantty

            };

            await preferredClass.UpdatePreferredClass(preferredClasses.PreferredClassID, preferredClasses);
           await App.Current.MainPage.DisplayAlert("Added to cart", "", "Ok");



             Application.Current.MainPage = new FlightTravellers();
            await PopupNavigation.Instance.PopAsync(true);
            
        }
    }
}