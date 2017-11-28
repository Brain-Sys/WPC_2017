using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
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
    public sealed partial class WheelPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        RacingWheel wheel;
        public WheelPage()
        {
            this.InitializeComponent();
            wheel = RacingWheel.RacingWheels.FirstOrDefault();

            // Not used
            var gamepads = Gamepad.Gamepads.ToList();
            var controllers = RawGameController.RawGameControllers.ToList();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (wheel == null) return;

            var reading = wheel.GetCurrentReading();
            this.BrakeValue.Text = ((int)(reading.Brake * 100)).ToString();
            this.ThrottleValue.Text = ((int)(reading.Throttle * 100)).ToString();
            this.AngleValue.Text = reading.Wheel.ToString();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            wheel = RacingWheel.RacingWheels.FirstOrDefault();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    }
}