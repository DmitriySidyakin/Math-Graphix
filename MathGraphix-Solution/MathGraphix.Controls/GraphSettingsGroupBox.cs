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

        private GroupBox CreateGraphSettingsGroupBox()
        {
            GroupBox newGroupBox = this;
            newGroupBox.Header = $"График {Number}";
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

            ColorPickerGrid cpg = new();
            cpg.Margin = new Thickness(480, -85, 0, 0);

            grid.Children.Add(isShownCheckBox);
            grid.Children.Add(isShownLabel);
            grid.Children.Add(colorLabel);
            grid.Children.Add(cpg);

            newGroupBox.Content = grid;

            return newGroupBox;
        }
    }
}
