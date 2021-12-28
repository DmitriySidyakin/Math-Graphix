using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathGraphix.Library
{
    public class GraphSettingsGroupBox : GroupBox
    {
        public int Number { get; }

        public GraphSettingsGroupBox(int i): base()
        {
            Number = i;

            CreateGraphSettingsGroupBox();
        }

        private void CreateGraphSettingsGroupBox()
        {
            Setup();

            Grid grid = new Grid();

            CheckBox isShownCheckBox = new();
            Label isShownLabel = new() { Content = "Отображать", Margin = new Thickness(15, -10, 0, 0) };
            Label colorLabel = new() { Content = "Цвет", Margin = new Thickness(730, -10, 0, 0) } ;
            ColorPickerGrid colorPickerGrid = new() { Margin = new Thickness(480, -85, 0, 0) };

            grid.Children.Add(isShownCheckBox);
            grid.Children.Add(isShownLabel);
            grid.Children.Add(colorLabel);
            grid.Children.Add(colorPickerGrid);

            this.Content = grid;
        }

        private void Setup()
        {
            this.Header = $"График {Number}";
            this.Width = 800;
            this.Height = 400;
            this.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#165072");
            this.Foreground = this.BorderBrush;
        }
    }
}
