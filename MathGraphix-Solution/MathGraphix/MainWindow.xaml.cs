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
        internal DrawingSettingsWindow drawingSettingsWindow = new DrawingSettingsWindow();
        internal ApplicationSettingsWindow applicationSettingsWindow = new ApplicationSettingsWindow();

       

        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
        }
        
        private void MainMenuItem_Draw_Click(object sender, RoutedEventArgs e)
        {
            drawingSettingsWindow.Show();
        }
        private void MainMenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            applicationSettingsWindow.Show();
        }

        private void MainMenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
