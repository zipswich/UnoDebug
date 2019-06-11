using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoDebug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<DeviceItem> _listDeviceItems = new ObservableCollection<DeviceItem>();
        public ObservableCollection<DeviceItem> listDeviceItems
        {
            get { return _listDeviceItems; }
            set
            {
                _listDeviceItems = value;
                NotifyPropertyChanged();
            }
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

        DeviceItem _diSelected = null;
        public DeviceItem diSelected
        {
            get { return _diSelected; }
            set
            {
                if (_diSelected == value)
                {
                    //do nothing
                }
                else
                {
                    _diSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            _listDeviceItems.Add(new DeviceItem
            {
                sName = "Test1",
                iTileWidth = 300,
            });
            _listDeviceItems.Add(new DeviceItem
            {
                sName = "Test2",
                iTileWidth = 300,
            });
            _listDeviceItems.Add(new DeviceItem
            {
                sName = "Test3",
                iTileWidth = 300,
            });
        }

        private void BtTest_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Debug.Write("Button is clicked");
        }

        private void Grid_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            Debug.Write("Holding has worked.");
        }

        private void LvDeviceTiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Write("Selected item:" + diSelected.ToString());
        }
    }
}
