using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Kulula.com.Helpers;
using Kulula.com.Services;
using Kulula.com.Models;
using System.Net.Http;
using Kulula.com.Views;
using System.Diagnostics;

namespace Kulula.com.ViewModels
{
    class loginViewModel
    {
        private UserService customerService = new UserService();
        private HttpResponseMessage responseMessage = new HttpResponseMessage();
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
              return new Command(async () =>
                {
                      var accessToken = await customerService.LoginAsync(Username, Password);

                      Settings.UserName = Username;
                      Settings.Password = Password;
                      Settings.AccessToken = accessToken;

                     if (accessToken != null)
                     {
                         Application.Current.MainPage = new HomePage();
                         Customer customerProfile = customerService.GetCustomerClaims();
                         Settings.CustomerID = customerProfile.CustomerID.ToString();
                        await App.Current.MainPage.DisplayAlert("Welcome To Kulula Application", Settings.UserName,"OK");
                     }
                     else{
                        await App.Current.MainPage.DisplayAlert("Login Failed", "Please check your email and password", "Close");
                        // Toast Notification Here
                    }

                });
            }
        }

      public loginViewModel()
        {
            Username = Settings.UserName;
            Password = Settings.Password;
        }
    }
}
