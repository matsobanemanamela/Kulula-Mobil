using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.ViewModels;
using Kulula.com.Views;
using Plugin.Messaging;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Payment : ContentPage
    {
        private PaymentService paymentService = new PaymentService();
        private FlightBookingService bookingService = new FlightBookingService();
        private CreditCardService cardService = new CreditCardService();
        private CartService cartService = new CartService();
        private PreferredClassService preferredClass = new PreferredClassService();
        private UserService userService = new UserService();

        string emails;
        string name;
        public Payment()
        {
            InitializeComponent();
           


            airpotname.Text = Helpers.Settings.AirportName;
            arrival.Text = Helpers.Settings.Arrivalairport;
            NumberOfTravellers.Text = Helpers.Settings.NumberOfTravellers;
            Departingdate.Text = Helpers.Settings.FlightDate;
            DepartTime.Text = Helpers.Settings.FlightDepartTime;
            aircraftname.Text = Helpers.Settings.Aircraft;
            date.Text = Helpers.Settings.FlightDate;
            ArrivalTime.Text = Helpers.Settings.ReturningFlightTime;
            extras.Text = Helpers.Settings.FlightExtras0;


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
            cartview.Text = "R" + carts[0].Totalprice.ToString();
        }
            private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dates = e.NewDate.ToString();
            var t1 = dates.Remove(10);
            Helpers.Settings.Date = t1;

        }
        private async void Submit(object sender, System.EventArgs e)
        {
          Payments payments;
            FlightBooking flightBooking;
            CreditCard creditCard;
            List<Cart> carts = await cartService.GetCart();
            List<Customer> customers = await userService.GetCustomers();

    for(int x = 0; x < customers.Count; x++)
            {
                if (customers[x].CustomerID == Convert.ToInt32(Helpers.Settings.CustomerID))
                {
                    emails = customers[x].Email;
                    name = customers[x].Firstname;
                }
            }

            creditCard = new CreditCard
            {
                CreditID = 0,
                PaymentID = null,
                CardNumber = CardNumber.Text,
                Cardname = Cardname.Text,
                ExpirationDate = Helpers.Settings.Date,
                Cvv = Cvv.Text,
                Address = Address.Text,
                Country = Country.Text,
                City = City.Text,
                PostalCode = PostalCode.Text
            };

            await cardService.AddCreditCards(creditCard);

            flightBooking = new FlightBooking
            {
                FlightID = 0,
                CustomerID = Convert.ToInt32(Helpers.Settings.CustomerID),
                AirportID = Convert.ToInt32(Helpers.Settings.AirportID),
                ExtraID = Convert.ToInt32(carts[0].ExtraID),
                SeatNumber = carts[0].SeatNumber,
                ReturningDate = " ",
                NumberOfTravellers = Convert.ToInt32(Helpers.Settings.NumberOfTravellers),
                TotalFare = carts[0].Totalprice

            };
            await bookingService.addflightBooking(flightBooking);

            payments = new Payments
            {

                PaymentID = 0,
                CustomerID = Convert.ToInt32(Helpers.Settings.CustomerID),
                PaymentType = "Credit Card",
                TotalAmount = carts[0].Totalprice
            };

            await paymentService.AddPayment(payments);

            await App.Current.MainPage.DisplayAlert("Successfully paid", "", "Ok");

            Application.Current.MainPage = new ConfirmationPage();

    
            string subject = "Booking";
               string body = "Good day " + name + "," + " " +
                "" +
                " thanks you for choosing to fly with us, would like to let you knw that your flight to " + Helpers.Settings.Arrivalairport + " was booked on this day " + Helpers.Settings.FlightDate + "" +
                "" +
                " Kind Regards " +
                "" +
                " Kulula Team";

               var mail = new MailMessage();
               var smtpServer = new SmtpClient("smtp.gmail.com", 587);
               mail.From = new MailAddress("matsobanemanamela@gmail.com");
               mail.To.Add(emails);
               mail.Subject = subject;
               mail.Body = body;
               smtpServer.Credentials = new NetworkCredential("matsobanemanamela@gmail.com", "07225309A");
               smtpServer.UseDefaultCredentials = false;
               smtpServer.EnableSsl = true;
               smtpServer.Send(mail);

            /*  MFMailComposeViewController mailController;

              if (MFMailComposeViewController.CanSendMail)
              {
                  mailController = new MFMailComposeViewController();
                  mailController.SetToRecipients(new string[] { "matsobanemanamela@gmail.com" });
                  mailController.SetSubject("mail test");
                  mailController.SetMessageBody("this is a test", false);
                  mailController.PresentViewController(mailController, true, null);
                  mailController.Finished += (object s, MFComposeResultEventArgs args) =>
                  {
                      Console.WriteLine(args.Result.ToString());
                      args.Controller.DismissViewController(true, null);

                  };


              }*/
        }
        void ShowPopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Viewcartpopup());
        }
    }
}