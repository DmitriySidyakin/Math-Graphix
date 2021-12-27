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
            GroupBox newGroupBox1 = CreateGraphSettingsGroupBox();

            newDockPanel.Children.Add(newGroupBox1);

            StackPanel_Graphs.Children.Add(newDockPanel);
        }

        private GroupBox CreateGraphSettingsGroupBox()
        {
            GroupBox newGroupBox = new GroupBox();
            newGroupBox.Header = $"График {CurrentCraphsCount}";
            newGroupBox.Width = 800;
            newGroupBox.Height = 400;
            newGroupBox.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#165072");
            newGroupBox.Foreground = newGroupBox.BorderBrush;

            Grid grid = new Grid();

            CheckBox isShownCheckBox = new CheckBox();
            Label isShownLabel = new Label();
            isShownLabel.Content = "Отображать";
            isShownLabel.Margin = new Thickness(15, -10, 0, 0);


            Label colorLabel = new Label();
            colorLabel.Content = "Цвет";
            colorLabel.Margin = new Thickness(730, -10, 0, 0);


            ListBox colorListBox = new ListBox();
            colorListBox.Width = 300;
            colorListBox.Height = 251;
            colorListBox.Margin = new Thickness(480, -85, 0, 0);

            Type type = typeof(Brushes);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
            foreach (PropertyInfo property in properties)
            {
                if(property.PropertyType == typeof(SolidColorBrush))
                {
                    Label colorText = new Label();
                    colorText.Content = property.Name;
                    colorText.Background = (SolidColorBrush)property.GetValue(null);
                    colorText.Width = 268;

                    colorListBox.Items.Add(colorText);
                }
            }

            grid.Children.Add(isShownCheckBox);
            grid.Children.Add(isShownLabel);
            grid.Children.Add(colorLabel);
            grid.Children.Add(colorListBox);

            newGroupBox.Content = grid;

            return newGroupBox;
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
