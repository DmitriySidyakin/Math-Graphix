using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathGraphix.Controls
{
    public class LinePickerGrid : Grid
    {

        public LinePickerGrid() : base() => CreateLinePickerGrid();

        private void CreateLinePickerGrid()
        {
            ListBox linePickerListBox = CreateLinePickerListBox();

            Children.Add(linePickerListBox);
        }

        private ListBox CreateLinePickerListBox()
        {
            this.Width = 310;

            ListBox linePickerListBox = new ListBox();
            linePickerListBox.Width = 310;
            linePickerListBox.Height = 135;
            for(int i = 0; i < 4; i++)
            {
                Label linePicker = new Label();
                linePicker.Width = linePickerListBox.Width - 15;
                linePicker.Height = 25;

                linePicker.Background = new SolidColorBrush(Colors.YellowGreen);
                linePickerListBox.Items.Add(linePicker);
            } 
            return linePickerListBox;
        }
    }
}
