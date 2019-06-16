using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //The following code shows CreationCollisionOption.ReplaceExisting is treated as CreationCollisionOption.OpenIfExists
            StorageFile sfFoo = await ApplicationData.Current.LocalFolder.CreateFileAsync("foo", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter dr = new StreamWriter(await sfFoo.OpenStreamForWriteAsync()))
            {
                await dr.WriteAsync("this is foo + foo");
                await dr.FlushAsync();
                dr.Close(); //Supposed to be redundant
            }
            StorageFile sfFoo2 = await ApplicationData.Current.LocalFolder.CreateFileAsync("foo", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter dr = new StreamWriter(await sfFoo.OpenStreamForWriteAsync()))
            {
                await dr.WriteAsync("this is abc");
                await dr.FlushAsync();
                dr.Close(); //Supposed to be redundant
            }

            StorageFile sfFooRead = await ApplicationData.Current.LocalFolder.GetFileAsync("foo");
            using (FileStream stream = File.OpenRead(sfFooRead.Path))
            using (StreamReader sr = new StreamReader(stream))
            {
                {
                    //The following outputs: "this is abc + foo"
                    //It is supposed to be: "this is abc"
                    Console.WriteLine(sr.ReadToEnd());
                }
            }

            try
            {
                await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync("foo.txt", CreationCollisionOption.ReplaceExisting);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception: " + ex);
            }

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
            try
            {
                Debug.Write("Selected item:" + diSelected);

                Grid grid = (Grid)findControlByName(lvDeviceTiles.ContainerFromIndex(1), "gridItem");
                FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(grid);
                flyoutBase.ShowAt(grid);
                Console.WriteLine("Selected item's Grid control name: " + grid.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception from LvDeviceTiles_SelectionChanged: " + ex);
            }
        }
        public static FrameworkElement findControlByName(object oParent, string sName)
        {
            FrameworkElement control = null;
            if (oParent is DependencyObject)
            {
                DependencyObject doParent = oParent as DependencyObject;
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(doParent); i++)
                {
                    DependencyObject doChild = VisualTreeHelper.GetChild(doParent, i);
                    try
                    {
                        if (doChild == null || !(doChild is FrameworkElement))
                        {
                            control = findControlByName(doChild, sName);
                        }
                        else
                        {
                            FrameworkElement ctr = doChild as FrameworkElement;
                            if (ctr.Name == sName)
                            {
                                control = ctr;
                                break;
                            }
                            else
                            {
                                control = findControlByName(doChild, sName);
                            }
                        }
                        if (control == null)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("This is Band-aid, so no big deal for exception:" + ex.Message);
                    }
                }
            }
            else
            {
                //do nothing
            }
            return control;
        }

        private void mfiUnoDebug_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Console.Write("mfiUnoDebug clicked");
        }

        private void mfiUnoTest_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Console.Write("mfiUnoTest clicked");
        }
    }
}
