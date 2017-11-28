using System.Collections.Generic;
using System.Reflection;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WPC_2017
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WindowsHelloPage : Page
    {
        public WindowsHelloPage()
        {
            this.InitializeComponent();

            var colors = new List<NamedColor>();
            foreach (var color in typeof(Colors).GetRuntimeProperties())
            {
                colors.Add(new NamedColor() { Name = color.Name, Color = (Color)color.GetValue(null) });
            }
            this.ChooseColors.ItemsSource = colors;
        }

        private void ChooseColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ChooseColors.SelectedItem == null) return;
            NamedColor nc = (NamedColor)this.ChooseColors.SelectedItem;
            this.MainGrid.Background = new SolidColorBrush(nc.Color);
        }
    }
    public class NamedColor
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}