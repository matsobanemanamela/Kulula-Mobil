using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Kulula.com.Helpers;
using Kulula.com.Models;
using Kulula.com.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace Kulula.com.ViewModels
{
    class datepicker : INotifyPropertyChanged
    {
        public datepicker()
        {
            FromMiminumDate = DateTime.Today;
        }

        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                if (_fromDate == value)
                    return;

                _fromDate = value;
                NotifyPropertyChanged(nameof(FromDate));
            }
        }

        private DateTime _toDate;
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                if (_toDate == value)
                    return;

                _toDate = value;
                NotifyPropertyChanged(nameof(ToDate));
            }
        }

        private DateTime _fromMiminumDate;
        public DateTime FromMiminumDate
        {
            get { return _fromMiminumDate; }
            set
            {
                if (_fromMiminumDate == value)
                    return;

                _fromMiminumDate = value;
                NotifyPropertyChanged(nameof(FromMiminumDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
