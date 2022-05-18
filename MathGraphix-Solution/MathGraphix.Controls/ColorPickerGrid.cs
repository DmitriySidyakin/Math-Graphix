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

        public Label selectedColor = new Label();
        public static Random rnd = new();
        public ColorPickerGrid() : base() => CreateColorPickerGrid();

        private void CreateColorPickerGrid()
        {
            ListBox colorListBox = CreateColorListBox();
            colorListBox.SelectionChanged += ColorListBox_SelectionChanged;
            
            selectedColor.Width = 300;
            selectedColor.Height = 75;
            
            selectedColor.Background = ((Label)colorListBox.Items[rnd.Next(0, colorListBox.Items.Count - 1)]).Background;
            selectedColor.BorderBrush = Brushes.Black;
            selectedColor.Margin = new Thickness(0, 335, 0, 0);

            Children.Add(colorListBox);
            Children.Add(selectedColor);
        }

        private void ColorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count == 1)
            {
                selectedColor.Background = ((Label)e.AddedItems[0]).Background;
            }
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
                    //colorText.Content = property.Name;
                    colorText.Background = (SolidColorBrush)property.GetValue(null);
                    colorText.Width = 268;
                    colorText.Height = 35;

                    colorListBox.Items.Add(colorText);
                }
            }
            
            return colorListBox;
        }
    }
}
