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
    public partial class TimeIntervalControlH : UserControl
    {
        private const int MAXLineNumber = 40;

        private const int NormalLineNumber = 20;

        private SolidColorBrush normalBrush = new SolidColorBrush(Color.FromRgb(255, 206, 57));

        private SolidColorBrush currentBrush = new SolidColorBrush();

        public TimeIntervalControlH()
        {
            InitializeComponent();

            currentBrush.Color = normalBrush.Color;
            currentBrush.Opacity = 0.75;

            timeIntervalContainer.Background = currentBrush;

            for (int i = 0; i < NormalLineNumber; i++)
            {
                timeIntervalContainer.ColumnDefinitions.Add(new ColumnDefinition());
                Line line = new Line();
                line.Width = 1;
                line.StrokeThickness = 1;
                line.Height = this.Width / 6;
                line.Y2 = this.Width / 6;
                line.Stroke = Brushes.White;
                Grid.SetColumn(line, i);
                timeIntervalContainer.Children.Add(line);
            }
        }


    }
}
