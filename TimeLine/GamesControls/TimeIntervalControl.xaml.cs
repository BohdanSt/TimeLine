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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLine.GamesControls
{
    /// <summary>
    /// Interaction logic for TimeIntervalControl.xaml
    /// </summary>
    public partial class TimeIntervalControl : UserControl
    {
        private const int MAXLineNumber = 30;

        private const int NormalLineNumber = 15;

        private SolidColorBrush normalBrush = new SolidColorBrush(Color.FromRgb(255, 206, 57));

        private SolidColorBrush currentBrush = new SolidColorBrush();

        public TimeIntervalControl()
        {
            InitializeComponent();

            currentBrush.Color = normalBrush.Color;
            currentBrush.Opacity = 0.75;

            timeIntervalContainer.Background = currentBrush;

            for (int i = 0; i < NormalLineNumber; i++)
            {
                timeIntervalContainer.RowDefinitions.Add(new RowDefinition());
                Line line = new Line();
                line.Height = 1;
                line.StrokeThickness = 1;
                line.Width = this.Width / 6;
                line.X2 = this.Width / 6;
                line.Stroke = Brushes.White;
                Grid.SetRow(line, i);
                timeIntervalContainer.Children.Add(line);
            }
        }


    }
}
