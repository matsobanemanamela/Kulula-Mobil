using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Kulula.com.Services;
using Kulula.com.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kulula.com.ViewModels
{
    class UpdateProfileViewModel
    {
        private UserService userService = new UserService();
        public Customer SelectedCustomer { get; set; }

        public UpdateProfileViewModel()
        {
            SelectedCustomer = new Customer();
            SelectedCustomer = (Customer)userService.GetCustomerClaims();
           
        }

        public ICommand UpdateCommand => new Command(async () =>
        {
            await userService.UpdateCustomer(SelectedCustomer.CustomerID, SelectedCustomer);
        });
    }
}
