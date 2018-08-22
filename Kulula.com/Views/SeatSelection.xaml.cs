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
	public partial class SeatSelection : ContentPage
	{
        private CartService cartService = new CartService();
        private FlightTravellerDetailsService flightTravellerService = new FlightTravellerDetailsService();
        private SeatSelectionService selectionService = new SeatSelectionService();

        string standardback = "Standard (back)";
        string standardfront = "Standard (Font)";
        string stretchzone = "Stretch Zone (Extra Legroom)";
        string ExitRow = "Exist Row (Extra Legroom)";
        string FrontRow = "Front Row (Extra Legroom)";

        double standardbackprice;
        double standardfrontprice;
        double stretchzoneprice;
        double ExitRowprice;
        double FrontRowprice;

      /*  string Selected_Standardback ;
        string Selected_Standardfront ;
        string Selected_Stretchzone ;
        string Selected_ExitRow;
        string Selected_FrontRow; */
        string allselectedseat;

        double allquantity;
    
        string seattype;
        public SeatSelection ()
		{
			InitializeComponent ();
            airpotname.Text = Settings.AirportName;
            arrival.Text = Settings.Arrivalairport;
            NumberOfTravellers.Text = Settings.NumberOfTravellers;
            Departingdate.Text = Settings.FlightDate;

            getspecifiedstandardBack.Text = "";
        }

        protected override async void OnAppearing()
        {
            List<SeatSelectionModel> seatSelections =  selectionService.GetSeatSelections();
            SeatSelectionModel seatSelectionModel = new SeatSelectionModel();
            List<SeatSelectionModel> selectionModels = new List<SeatSelectionModel>();
            List<SeatSelectionModel> seats = new List<SeatSelectionModel>();
            List<SeatSelectionModel> seatSelectionsmat = new List<SeatSelectionModel>();
            List<SeatSelectionModel> seatsele = new List<SeatSelectionModel>();
            List<SeatSelectionModel> seatschange = new List<SeatSelectionModel>();
            List<SeatSelectionModel> allseats = new List<SeatSelectionModel>();
            List<Cart> carts = await cartService.GetCart();
            base.OnAppearing();
            
            // Standard back seat for loop
            for (int x = 0; x < seatSelections.Count; x++)
            {
                
                if (seatSelections[x].SeatType == FrontRow)
                {
                    if (seatSelections[x].Quantity == 1) {
                        seatSelectionModel = new SeatSelectionModel
                        {

                            SeatNumber = seatSelections[x].SeatNumber,
                            SeatType = seatSelections[x].SeatType,
                            Price = seatSelections[x].Price,
                            Quantity = seatSelections[x].Quantity,
                            Total = seatSelections[x].Total,
                            AirportID = seatSelections[x].AirportID,
                        };
                        seats.Add(seatSelectionModel);
                        FrontRowprice = seatSelectionModel.Price;
                       // frontrowquantity = seatSelectionModel.Quantity;
                    }
                }
               
            }
            
            // standardfront loop 
            for (int x = 0; x < seatSelections.Count; x++)
            {
                if (seatSelections[x].SeatType == standardfront)
                {
                    if (seatSelections[x].Quantity == 1)
                    {
                        seatSelectionModel = new SeatSelectionModel
                        {
                            SeatNumber = seatSelections[x].SeatNumber,
                            SeatType = seatSelections[x].SeatType,
                            Price = seatSelections[x].Price,
                            Quantity = seatSelections[x].Quantity,
                            Total = seatSelections[x].Total,
                            AirportID = seatSelections[x].AirportID,
                        };
                        selectionModels.Add(seatSelectionModel);
                        standardfrontprice = seatSelectionModel.Price;
                      //  standardfrontquantity = seatSelectionModel.Quantity;
                    }
                }
            }
            // stretchzone loop
            for (int x = 0; x < seatSelections.Count; x++)
            {
                if (seatSelections[x].SeatType == stretchzone)
                {
                    if (seatSelections[x].Quantity == 1)
                    {
                        seatSelectionModel = new SeatSelectionModel
                        {
                            SeatNumber = seatSelections[x].SeatNumber,
                            SeatType = seatSelections[x].SeatType,
                            Price = seatSelections[x].Price,
                            Quantity = seatSelections[x].Quantity,
                            Total = seatSelections[x].Total,
                            AirportID = seatSelections[x].AirportID,
                        };
                        seatSelectionsmat.Add(seatSelectionModel);
                        stretchzoneprice = seatSelectionModel.Price;
                      //  stretchzonequantity = seatSelectionModel.Quantity;
                    }
                }
            }
            // ExitRow loop
            for (int x = 0; x < seatSelections.Count; x++)
            {
                if (seatSelections[x].SeatType == ExitRow)
                {
                    if (seatSelections[x].Quantity == 1)
                    {
                        seatSelectionModel = new SeatSelectionModel
                        {
                            SeatNumber = seatSelections[x].SeatNumber,
                            SeatType = seatSelections[x].SeatType,
                            Price = seatSelections[x].Price,
                            Quantity = seatSelections[x].Quantity,
                            Total = seatSelections[x].Total,
                            AirportID = seatSelections[x].AirportID,
                        };
                        seatsele.Add(seatSelectionModel);
                        ExitRowprice = seatSelectionModel.Price;
                      //  exitrowquantity = seatSelectionModel.Quantity;
                    }
                }
            }

            // standardback loop 

            for (int x = 0; x < seatSelections.Count; x++)
            {
                if (seatSelections[x].SeatType == standardback)
                {
                    if (seatSelections[x].Quantity == 1)
                    {
                        seatSelectionModel = new SeatSelectionModel
                        {
                            SeatNumber = seatSelections[x].SeatNumber,
                            SeatType = seatSelections[x].SeatType,
                            Price = seatSelections[x].Price,
                            Quantity = seatSelections[x].Quantity,
                            Total = seatSelections[x].Total,
                            AirportID = seatSelections[x].AirportID,
                        };
                        seatschange.Add(seatSelectionModel);
                        standardbackprice = seatSelectionModel.Price;
                      //  standardbackquantity = seatSelectionModel.Quantity;
                    }
                }
            }
            // loop for all seats infor
            for (int x = 0; x < seatSelections.Count; x++)
            {
                if (seatSelections[x].Quantity == 1)
                {
                    seatSelectionModel = new SeatSelectionModel
                    {
                        SeatNumber = seatSelections[x].SeatNumber
                    };
                    seattype = seatSelections[x].SeatType;
                    allquantity = seatSelections[x].Quantity;
                    allseats.Add(seatSelectionModel);
                }

            }


                Picker picker;
            picker = new Picker();
            picker.Title = "select your FontBack seat";
            picker.ItemsSource = seats;

            // text for seat price
            getspecifiedstandardBack.Text = standardback + " " + "Price:" + "R" + standardbackprice;
            getspecifiedstandardfront.Text = standardfront + " " + "Price:" + "R" + standardfrontprice;
            getspecifiedExitRow.Text = ExitRow + " " + "Price:" + "R" + ExitRowprice;
            getspecifiedFrontRow.Text = FrontRow + " " + "Price:" + "R" + FrontRowprice;
            getspecifiedstretchzone.Text = stretchzone + " " + "Price:" + "R" +stretchzoneprice; 
              // seats picker selections
              flight_Departuresd.ItemsSource = seats;
            StandardFonts.ItemsSource = selectionModels;
            stretchzones.ItemsSource = seatSelectionsmat;
            existsrow.ItemsSource = seatsele;
            standrdbacks.ItemsSource = seatschange;

             AllSeat.ItemsSource = allseats;
            cartview.Text = "R" + carts[0].Totalprice.ToString();
        }
        private void Button_FlghtExtras(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Flight_Extras();
        }
        private async void Button_Cart_Submit_Seat(object sender, EventArgs e)
        {
            List<SeatSelectionModel> seatSelections = selectionService.GetSeatSelections();
            List<Cart> carts = await cartService.GetCart();
            Cart cart;
            SeatSelectionModel seatSelectionModel;
            string de = "dd";
            //Selected Front Row Function to add to cart
    
           
                cart = new Cart
                {
                    CartID = carts[0].CartID,
                    SeatNumber = allselectedseat,
                    PreferredClassID = carts[0].PreferredClassID,
                    ExtraID = null,
                    Totalprice = FrontRowprice + carts[0].Totalprice,
                    Quantity = carts[0].Quantity

                };
                await cartService.AddCart(cart);
                await cartService.UpdateCart(cart.CartID, cart);

                seatSelectionModel = new SeatSelectionModel
                {
                    SeatType = seattype,
                    SeatNumber = allselectedseat,
                    AirportID = Convert.ToInt32(Settings.AirportID),
                    Price = FrontRowprice,
                    Quantity = allquantity - 1,
                    Total = FrontRowprice * Convert.ToInt32(Settings.NumberOfTravellers)


                };

                await selectionService.UpdateSeatSelection(seatSelectionModel.SeatNumber, seatSelectionModel);

                await App.Current.MainPage.DisplayAlert("Added to cart", "", "Ok");
            

         
        }
        private void flight_Departuresd_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  var front = flight_Departuresd.Items[flight_Departuresd.SelectedIndex];
            Selected_FrontRow = front; */

        }

        private void standrdbacks_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* var standback = standrdbacks.Items[standrdbacks.SelectedIndex];
            Selected_Standardback = standback;*/
        }

        private void existsrow_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  var exixts = existsrow.Items[existsrow.SelectedIndex];
            Selected_ExitRow = exixts;*/
        }

        private void stretchzones_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* var strech = stretchzones.Items[stretchzones.SelectedIndex];
            Selected_Stretchzone = strech; */
        }

        private void StandardFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* var standardsfon = StandardFonts.Items[StandardFonts.SelectedIndex];
            Selected_Standardfront = standardsfon;*/
        }

        private void AllSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allseat = AllSeat.Items[AllSeat.SelectedIndex];
            allselectedseat = allseat;
        }

        void ShowPopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Viewcartpopup());
        }
    }
}