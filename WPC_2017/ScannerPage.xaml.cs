using Windows.Devices.Enumeration;
using Windows.Devices.Scanners;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace WPC_2017
{
    public sealed partial class ScannerPage : Page
    {
        DeviceWatcher scannerWatcher;

        public ScannerPage()
        {
            this.InitializeComponent();

            scannerWatcher = DeviceInformation.CreateWatcher(DeviceClass.ImageScanner);
            scannerWatcher.Added += OnScannerAdded;
            scannerWatcher.Removed += ScannerWatcher_Removed;
            scannerWatcher.EnumerationCompleted += ScannerWatcher_EnumerationCompleted;
            scannerWatcher.Start();
        }

        private async void ScannerWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ItemCollection collection = this.ScannersList.Items;
                DeviceInformation di = null;

                foreach (ScannerItem item in collection)
                {
                    if (item.ScannerHardware.Id == args.Id)
                    {
                        di = item.ScannerHardware;
                        break;
                    }
                }

                if (di != null)
                {
                    this.ScannersList.Items.Remove(di);
                }
            });
        }

        private async void ScannerWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                MessageDialog dlg = new MessageDialog("Scanners detection completed!");
                await dlg.ShowAsync();
            });
        }

        private async void OnScannerAdded(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ScannerItem si = new ScannerItem();
                si.Description = deviceInfo.Name;
                si.ScannerHardware = deviceInfo;
                this.ScannersList.Items.Add(si);
            }
            );
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ScannerItem si = btn.DataContext as ScannerItem;
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var myScanner = await ImageScanner.FromIdAsync(si.ScannerHardware.Id);

                if (si.ScannerHardware.IsEnabled)
                {
                    var result = await myScanner.ScanFilesToFolderAsync(ImageScannerScanSource.Default, folder);
                }
                else
                {
                    MessageDialog dlg = new MessageDialog("This scanner is not available, sorry...");
                    await dlg.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog("This scanner is not available, sorry...");
                await dlg.ShowAsync();
            }
        }
    }
}