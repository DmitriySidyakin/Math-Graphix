using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathGraphix.Controls
{
    public class GraphSettingsGroupBox : GroupBox
    {
        public int Number { get; }

        public CheckBox isShownCheckBox;
        public Label isShownLabel;
        public Label colorLabel;
        public ColorPickerGrid colorPickerGrid;
        public ComboBox graphFunctionList;
        public Label widthLabel;
        public Slider widthSlider;
        public TextBox widthTextBox;
        public Label aLabel;
        public Label bLabel;
        public Label cLabel;
        public Label dLabel;
        public Label zLabel;
        public Label lLabel;
        public Label kLabel;
        public Label hLabel;
        public TextBox aTextBox;
        public TextBox bTextBox;
        public TextBox cTextBox;
        public TextBox dTextBox;
        public TextBox zTextBox;
        public TextBox lTextBox;
        public TextBox kTextBox;
        public TextBox hTextBox;
        public Label lineTypeLabel;
        public LinePickerGrid linePickerGrid;

        public static int widthSliderMinimum = 1; 
        public string widthTextBoxPreviousValue = widthSliderMinimum.ToString();

        private string selectFunctionString = "Выберите функцию...";

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

            
            graphFunctionList = new() { Margin = new Thickness(15, 40, 0, 0), Width = 400, Height = 30, Text = selectFunctionString, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
            graphFunctionList.Items.Add("Выберите функцию...");
            graphFunctionList.SelectedIndex = 0;
            graphFunctionList.Items.Add("y = a (y=константа)");
            graphFunctionList.Items.Add("x = a (x=константа)");
            graphFunctionList.Items.Add("y = ax+b (линейная)");
            graphFunctionList.Items.Add("y = ax²+bx+c (парабола)");
            graphFunctionList.Items.Add("y = ax³+bx²+cx+d (гипербола)");
            graphFunctionList.Items.Add("y =  ax⁴+bx³+cx²+dx+z (степенная четвёртой степени)");
            graphFunctionList.Items.Add("y = c:(ax+b)+d (деление на x)");
            graphFunctionList.Items.Add("y = d:(ax²+bx+c)+z (деление на параболу)");
            graphFunctionList.Items.Add("y = z:(ax³+bx²+cx+d)+k (деление на гиперболу)");
            graphFunctionList.Items.Add("y = k:(ax⁴+bx³+cx²+dx+z)+l (деление на степенную четвёртой степени)");
            graphFunctionList.Items.Add("y = c|ax+b|+d (модуль числа)");
            graphFunctionList.Items.Add("y = c√(ax+b)+d (квадратный корень)");
            graphFunctionList.Items.Add("y = c³√(ax+b)+d (кубический корень)");
            graphFunctionList.Items.Add("y = ceᵃᵡ⁺ᵇ+d (експонента)");
            graphFunctionList.Items.Add("y = clog₁₀(ax+b)+d (десятичный логарифм)");
            graphFunctionList.Items.Add("y = clog₂(ax+b)+d (двоичный логарифм)");
            graphFunctionList.Items.Add("y = cln(ax+b)+d (натуральный логарифм)");
            graphFunctionList.Items.Add("y = csin(ax+b)+d (синус)");
            graphFunctionList.Items.Add("y = ccos(ax+b)+d (косинус)");
            graphFunctionList.Items.Add("y = ctg(ax+b)+d (тангенс)");
            graphFunctionList.Items.Add("y = cctg(ax+b)+d (котангенс)");
            graphFunctionList.Items.Add("y = carcsin(ax+b)+d (арксинус)");
            graphFunctionList.Items.Add("y = carccos(ax+b)+d (арккосинус)");
            graphFunctionList.Items.Add("y = carctg(ax+b)+d (арктангенс)");
            graphFunctionList.Items.Add("y = carcctg(ax+b)+d (арккотангенс)");
            graphFunctionList.Items.Add("y = сsh(ax+b)+d (гиперболический синус)");
            graphFunctionList.Items.Add("y = ссh(ax+b)+d (гиперболический косинус)");
            graphFunctionList.Items.Add("y = сth(ax+b)+d (гиперболический тангенс)");
            graphFunctionList.Items.Add("y = сcth(ax+b)+d (гиперболический котангенс)");
            graphFunctionList.Items.Add("y = сsch(ax+b)+d (гиперболический секанс)");
            graphFunctionList.Items.Add("y = сcsch(ax+b)+d (гиперболический косеканс)");
            graphFunctionList.Items.Add("y = сarsh(ax+b)+d (обратный гиперболический синус)");
            graphFunctionList.Items.Add("y = сarсh(ax+b)+d (обратный гиперболический косинус)");
            graphFunctionList.Items.Add("y = сarth(ax+b)+d (обратный гиперболический тангенс)");
            graphFunctionList.Items.Add("y = сarcth(ax+b)+d (обратный гиперболический котангенс)");
            graphFunctionList.Items.Add("y = сarsch(ax+b)+d (обратный гиперболический секанс)");
            graphFunctionList.Items.Add("y = сarcsch(ax+b)+d (обратный гиперболический косеканс)");
            graphFunctionList.SelectionChanged += GraphFunctionList_SelectionChanged;

            widthLabel = new() { Content = "Ширина", Margin = new Thickness(10, 75, 0, 0), Visibility = Visibility.Hidden };
            widthSlider = new() { Margin = new Thickness(90, 85, 0, 0), Width = 150, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Minimum = widthSliderMinimum, Maximum = 100, IsSelectionRangeEnabled = true, IsSnapToTickEnabled = true, Visibility = Visibility.Hidden };
            widthTextBox = new() { Margin = new Thickness(255, 85, 0, 0), Width = 160, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            widthSlider.ValueChanged += WidthSlider_ValueChanged;
            widthTextBox.TextChanged += WidthTextBox_TextChanged;

            aLabel = new() { Content = "a", Margin = new Thickness(10, 110, 0, 0), Visibility = Visibility.Hidden };
            aTextBox = new() { Margin = new Thickness(30, 115, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
           
            bLabel = new() { Content = "b", Margin = new Thickness(10, 135, 0, 0), Visibility = Visibility.Hidden };
            bTextBox = new() { Margin = new Thickness(30, 140, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            
            cLabel = new() { Content = "c", Margin = new Thickness(10, 160, 0, 0), Visibility = Visibility.Hidden };
            cTextBox = new() { Margin = new Thickness(30, 165, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            
            dLabel = new() { Content = "d", Margin = new Thickness(10, 185, 0, 0), Visibility = Visibility.Hidden };
            dTextBox = new() { Margin = new Thickness(30, 190, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            
            zLabel = new() { Content = "z", Margin = new Thickness(220, 110, 0, 0), Visibility = Visibility.Hidden };
            zTextBox = new() { Margin = new Thickness(240, 115, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            
            lLabel = new() { Content = "l", Margin = new Thickness(220, 135, 0, 0), Visibility = Visibility.Hidden };
            lTextBox = new() { Margin = new Thickness(240, 140, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            
            kLabel = new() { Content = "k", Margin = new Thickness(220, 160, 0, 0), Visibility = Visibility.Hidden };
            kTextBox = new() { Margin = new Thickness(240, 165, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };
            
            hLabel = new() { Content = "h", Margin = new Thickness(220, 185, 0, 0), Visibility = Visibility.Hidden };
            hTextBox = new() { Margin = new Thickness(240, 190, 0, 0), Width = 175, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Text = "1", Visibility = Visibility.Hidden };

            lineTypeLabel = new() { Content = "Тип линии", Margin = new Thickness(10, 215, 0, 0), Visibility = Visibility.Hidden };
            linePickerGrid = new() { Margin = new Thickness(105, 225, 0, 0), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Visibility = Visibility.Hidden };

            grid.Children.Add(isShownCheckBox);
            grid.Children.Add(isShownLabel);

            grid.Children.Add(graphFunctionList);

            grid.Children.Add(widthLabel);
            grid.Children.Add(widthSlider);
            grid.Children.Add(widthTextBox);

            grid.Children.Add(aLabel); grid.Children.Add(aTextBox);
            grid.Children.Add(bLabel); grid.Children.Add(bTextBox);
            grid.Children.Add(cLabel); grid.Children.Add(cTextBox);
            grid.Children.Add(dLabel); grid.Children.Add(dTextBox);
            grid.Children.Add(zLabel); grid.Children.Add(zTextBox);
            grid.Children.Add(lLabel); grid.Children.Add(lTextBox);
            grid.Children.Add(kLabel); grid.Children.Add(kTextBox);
            grid.Children.Add(hLabel); grid.Children.Add(hTextBox);

            grid.Children.Add(lineTypeLabel);
            grid.Children.Add(linePickerGrid);

            grid.Children.Add(colorLabel);
            grid.Children.Add(colorPickerGrid);

            this.Content = grid;
        }

        private void WidthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(widthTextBox.Text.Length == 0 || widthTextBox.Text[0] == '0')
            {
                widthTextBox.Text = widthTextBoxPreviousValue;
                return;
            }
                
            if (int.TryParse(widthTextBox.Text, out int value))
            {
                if(value < widthSlider.Minimum || value > widthSlider.Maximum)
                {
                    widthTextBox.Text = widthTextBoxPreviousValue;
                }
                else
                {
                    widthTextBoxPreviousValue = value.ToString();
                    widthSlider.Value = value;
                }
            }
            else
            {
                widthTextBox.Text = widthTextBoxPreviousValue;
            }
        }

        private void WidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            widthTextBox.Text = e.NewValue.ToString();
        }

        private void GraphFunctionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Header = $"График {Number}";
            if (e.AddedItems.Count == 1)
            {
                if (!e.AddedItems[0].Equals(selectFunctionString))
                {
                    this.Header += $" [{e.AddedItems[0]}]";
                   
                    SetGraphParametersVisibilityStatus(Visibility.Visible);
                }
                else
                {
                    SetGraphParametersVisibilityStatus(Visibility.Hidden);
                    widthSlider.Value = widthSliderMinimum;
                }

                switch (e.AddedItems[0])
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

        private void SetGraphParametersVisibilityStatus(Visibility status)
        {
            widthLabel.Visibility = status;
            widthSlider.Visibility = status;
            widthTextBox.Visibility = status;

            lineTypeLabel.Visibility = status;
            linePickerGrid.Visibility = status;

            aLabel.Visibility = status; aTextBox.Visibility = status;
            bLabel.Visibility = status; bTextBox.Visibility = status;
            cLabel.Visibility = status; cTextBox.Visibility = status;
            dLabel.Visibility = status; dTextBox.Visibility = status;
            zLabel.Visibility = status; zTextBox.Visibility = status;
            lLabel.Visibility = status; lTextBox.Visibility = status;
            kLabel.Visibility = status; kTextBox.Visibility = status;
            hLabel.Visibility = status; hTextBox.Visibility = status;

            
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
