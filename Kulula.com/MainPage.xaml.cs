using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Kulula.com.Views;
using Kulula.com.Models;
using Kulula.com.Services;
using Kulula.com.Helpers;
using System.Net.Http;

namespace Kulula.com
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            HttpResponseMessage HttpResponseMessage = new HttpResponseMessage();
            Settings.AccessToken = "";

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        private void Create_Account_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegitrationPage();
        }

    }
}
