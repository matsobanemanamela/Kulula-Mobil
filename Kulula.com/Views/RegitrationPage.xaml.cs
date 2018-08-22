using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegitrationPage : ContentPage
	{
		public RegitrationPage ()
		{
			InitializeComponent ();
		}

        private void Sign_IN_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}