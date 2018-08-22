using Kulula.com.Services;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Viewcartpopup 
	{
        private PaymentService paymentService = new PaymentService();
        private FlightBookingService bookingService = new FlightBookingService();
        private CreditCardService cardService = new CreditCardService();
        private CartService cartService = new CartService();
        private PreferredClassService preferredClass = new PreferredClassService();
        private UserService userService = new UserService();
        public Viewcartpopup ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            List<Cart> carts = await cartService.GetCart();
            List<PreferredClass> preferredClasses = await preferredClass.GetPreferredClasses();
            PreferredClass preferred = new PreferredClass();
            base.OnAppearing();

            for (int z = 0; z < preferredClasses.Count; z++)
            {

                if (preferredClasses[z].PreferredClassID == carts[0].PreferredClassID)
                {

                    Fares.Text = "R" + preferredClasses[z].Price.ToString();
                }
            }

            TotalAmount.Text = "R" + carts[0].Totalprice.ToString();
            extras.Text = Settings.FlightExtras0;
            // cartview.Text = "R" + carts[0].Totalprice.ToString();
           // await PopupNavigation.Instance.PopAsync(true);
        }
        private async void Handle_clicked(object sender, System.EventArgs e)
        {
           // Application.Current.MainPage = new FlightTravellers();
            await PopupNavigation.Instance.PopAsync(true);
        }
        }
}