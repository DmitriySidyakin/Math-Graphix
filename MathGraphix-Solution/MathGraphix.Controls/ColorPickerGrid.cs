using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathGraphix.Library
{
    public class ColorPickerGrid : Grid
    {
        public int Number { get; }

        public ColorPickerGrid() : base() => CreateColorPickerGrid();

        private void CreateColorPickerGrid()
        {
            ListBox colorListBox = CreateColorListBox();

            Label selectedColor = new Label();
            selectedColor.Width = 300;
            selectedColor.Height = 75;
            selectedColor.Background = Brushes.Red;
            selectedColor.BorderBrush = Brushes.Black;
            selectedColor.Margin = new Thickness(0, 335, 0, 0);
            selectedColor.Content = "Red";
            selectedColor.VerticalContentAlignment = VerticalAlignment.Center;
            selectedColor.HorizontalContentAlignment = HorizontalAlignment.Center;

            Children.Add(colorListBox);
            Children.Add(selectedColor);

        }

        private ListBox CreateColorListBox()
        {
            this.Width = 300;
            ListBox colorListBox = new ListBox();
            colorListBox.Width = 300;
            colorListBox.Height = 251;

            Type type = typeof(Brushes);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(SolidColorBrush))
                {
                    Label colorText = new Label();
                    colorText.Content = property.Name;
                    colorText.Background = (SolidColorBrush)property.GetValue(null);
                    colorText.Width = 268;

                    colorListBox.Items.Add(colorText);
                }
            }

            return colorListBox;
        }
    }
}
