﻿using System;
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


            ListBox colorListBox = new ListBox();
            colorListBox.Width = 300;
            colorListBox.Height = 251;
            colorListBox.Margin = new Thickness(480, -85, 0, 0);

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

            grid.Children.Add(isShownCheckBox);
            grid.Children.Add(isShownLabel);
            grid.Children.Add(colorLabel);
            grid.Children.Add(colorListBox);

            newGroupBox.Content = grid;

            return newGroupBox;
        }
    }
}