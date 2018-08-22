using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Emit;
using Xamarin.Forms;
using Kulula.com.Views;
using Kulula.com.ViewModels;

namespace Kulula.com
{
    class splash : ContentPage
    {
        Image splashImage;

        public splash()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "Kulula_500x500.jpg",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new HomePage());    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}
