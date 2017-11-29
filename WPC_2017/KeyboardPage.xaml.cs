using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WPC_2017
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KeyboardPage : Page
    {
        public KeyboardPage()
        {
            this.InitializeComponent();
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dlg = new MessageDialog("Share!");
            await dlg.ShowAsync();
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageDialog dlg = new MessageDialog("Copy!");
            await dlg.ShowAsync();
        }

        private async void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            MessageDialog dlg = new MessageDialog("Delete!");
            await dlg.ShowAsync();
        }

        private async void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            MessageDialog dlg = new MessageDialog("Rename!");
            await dlg.ShowAsync();
        }

        private async void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            MessageDialog dlg = new MessageDialog("Select All!");
            await dlg.ShowAsync();
        }

        private async void KeyboardAccelerator_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            MessageDialog dlg = new MessageDialog("Help per Button 1!");
            await dlg.ShowAsync();
        }
    }
}