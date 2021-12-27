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
            e.Cancel = true;  // Cancels the window close    
            this.Hide();      // Programmatically hides the window
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
            newDockPanel.Height = 200;
            newDockPanel.HorizontalAlignment = HorizontalAlignment.Center;

            CurrentCraphsCount++;
            GroupBox newGroupBox1 = CreateGraphSettingsGroupBox();

            newDockPanel.Children.Add(newGroupBox1);

            CurrentCraphsCount++;
            GroupBox newGroupBox2 = CreateGraphSettingsGroupBox();

            newDockPanel.Children.Add(newGroupBox2);

            StackPanel_Graphs.Children.Add(newDockPanel);
        }

        private GroupBox CreateGraphSettingsGroupBox()
        {
            GroupBox newGroupBox = new GroupBox();
            newGroupBox.Header = $"График {CurrentCraphsCount}";
            newGroupBox.Width = 400;
            newGroupBox.Height = 200;
            newGroupBox.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#165072");
            newGroupBox.Foreground = newGroupBox.BorderBrush;

            StackPanel sp = new StackPanel();

            CheckBox isShownCheckBox = new CheckBox();
            Label isShownLabel = new Label();
            isShownLabel.Content = "Отображать";

            sp.Children.Add(isShownCheckBox);
            sp.Children.Add(isShownLabel);

            newGroupBox.Content = sp;

            return newGroupBox;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDockPanel();
        }
    }
}
