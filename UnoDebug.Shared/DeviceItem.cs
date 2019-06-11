using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace UnoDebug
{
    public class DeviceItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string sName { get; set; }
        string _sSatus;
        public string sStatus
        {
            get { return _sSatus; }
            set
            {
                _sSatus = value;
                NotifyPropertyChanged();
            }
        }
        public string sType { get; set; }
        public string sCapabilities { get; set; }

        BitmapImage _bmp;
        public BitmapImage bmp
        {
            get { return _bmp; }
            set
            {
                _bmp = value;
                NotifyPropertyChanged();
            }
        }
        public double iDebug
        {
            get { return 300; }
        }


        double _iTileWidth = 300;
        public double iTileWidth
        {
            get { return _iTileWidth; }
            set
            {
                _iTileWidth = value;
                iTileHeight = value * 3 / 4;
                NotifyPropertyChanged();
            }
        }


        double _iTileHeight = 200;
        public double iTileHeight
        {
            get { return _iTileHeight; }
            set
            {
                _iTileHeight = value;
                NotifyPropertyChanged();
            }
        }


        Thickness _iImageMargin = new Thickness(0);
        public Thickness iImageMargin
        {
            get { return _iImageMargin; }
            set
            {
                _iImageMargin = value;
                NotifyPropertyChanged();
            }
        }



        public double iTileFontSize
        {
            get
            {
                double iFontSize = Math.Max(7, iTileWidth / 15);
                iFontSize = Math.Min(20, iFontSize);
                return iFontSize;
            }
        }


    }
}
