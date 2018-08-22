using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Kulula.com.Helpers;
using Kulula.com.Views;
using Kulula.com.Models;
using Kulula.com.Services;
using Xamarin.Forms;

namespace Kulula.com.ViewModels
{
    class RegisterViewModel
    {
        private UserService customerService = new UserService();

        public Customer SelectedCustomer { get; set; }

        public ICommand RegisterCommand => new Command(async () =>
        {
            await customerService.AddCustomer(SelectedCustomer);

            Settings.UserName = SelectedCustomer.UserName;
            Settings.Password = SelectedCustomer.Password;
        });

        public RegisterViewModel()
        {
            SelectedCustomer = new Customer();
        }
    }
}
