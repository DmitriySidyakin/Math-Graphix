using MathGraphix.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MathGraphix
{
    /// <summary>
    /// Логика взаимодействия для DrawingSettingsWindow.xaml
    /// </summary>
    public partial class DrawingSettingsWindow : Window
    {
        internal static DrawingSettingsWindow Instance;

        internal static int CurrentCraphsCount = 0;

        public DrawingSettingsWindow()
        {
            InitializeComponent();
            Instance = this;
            AddDockPanel();
            AddDockPanel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;    // Отменяем закрытие окна  
            this.Hide();    // Программно скрываем окно
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_Graphs.Children.Clear();
            CurrentCraphsCount = 0;
            AddDockPanel();
            AddDockPanel();
        }

        private void AddDockPanel()
        {
            DockPanel newDockPanel = new DockPanel();
            newDockPanel.Width = 800;
            newDockPanel.Height = 400;
            newDockPanel.HorizontalAlignment = HorizontalAlignment.Center;

            CurrentCraphsCount++;
            GroupBox newGroupBox1 = new GraphSettingsGroupBox(CurrentCraphsCount);

            newDockPanel.Children.Add(newGroupBox1);

            StackPanel_Graphs.Children.Add(newDockPanel);
        }

        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDockPanel();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {


            this.Hide();    // Программно скрываем окно
        }
    }
}
