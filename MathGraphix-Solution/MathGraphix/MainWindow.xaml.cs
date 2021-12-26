using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathGraphix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;

            StackPanel_Graph.Background = Brushes.AntiqueWhite;
        }
        
        private void MenuItem_Draw_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush[] colorBrushValues = new SolidColorBrush[] { Brushes.AliceBlue, Brushes.AntiqueWhite, Brushes.Wheat, Brushes.Coral, Brushes.Red, Brushes.Yellow };
            Random random = new Random();
            StackPanel_Graph.Background = (SolidColorBrush)colorBrushValues[random.Next(colorBrushValues.Length)];
        }
    }
}
