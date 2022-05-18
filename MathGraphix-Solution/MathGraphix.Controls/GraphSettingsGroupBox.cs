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

        public CheckBox isShownCheckBox;
        public Label isShownLabel;
        public Label colorLabel;
        public ColorPickerGrid colorPickerGrid;
        public ComboBox graphFunctionList;

        public GraphSettingsGroupBox(int i): base()
        {
            Number = i;

            CreateGraphSettingsGroupBox();
        }

        private void CreateGraphSettingsGroupBox()
        {
            Setup();

            Grid grid = new Grid();

            isShownCheckBox = new() { Margin = new Thickness(15, 10, 0, 0) }; ;
            isShownLabel = new() { Content = "Отображать", Margin = new Thickness(30, 0, 0, 0) };
            colorLabel = new() { Content = "Цвет", Margin = new Thickness(730, 0, 0, 0) };
            colorPickerGrid = new() { Margin = new Thickness(480, -65, 0, 0) };

            
            graphFunctionList = new() { Margin = new Thickness(15, 40, 0, 0), Width = 400, Height = 30, Text = "Выберите функцию...", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
            graphFunctionList.Items.Add("Выберите функцию...");
            graphFunctionList.SelectedIndex = 0;
            graphFunctionList.Items.Add("y = a");
            graphFunctionList.Items.Add("x = a");
            graphFunctionList.SelectionChanged += GraphFunctionList_SelectionChanged;

            grid.Children.Add(isShownCheckBox);
            grid.Children.Add(isShownLabel);
            grid.Children.Add(graphFunctionList);
            grid.Children.Add(colorLabel);
            grid.Children.Add(colorPickerGrid);
            

            this.Content = grid;
        }

        private void GraphFunctionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Header = $"График {Number} [{e.AddedItems[0]}]";
            if (e.AddedItems.Count == 1)
            {
                switch(e.AddedItems[0])
                {
                    case "y = a":
                        {
 
                        }
                        break;
                    case "x = a":
                        {

                        }
                        break;
                }
            }
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
