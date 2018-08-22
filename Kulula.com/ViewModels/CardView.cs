using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kulula.com.ViewModels
{
    class CardView : Frame
    {
        public CardView()
        {

            Padding = 0;
            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = false;
                OutlineColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }
          else  if (Device.RuntimePlatform == Device.UWP)
            {
                HasShadow = false;
                OutlineColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                HasShadow = false;
                OutlineColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }
        }
    }
}
