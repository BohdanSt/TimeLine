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
    /// Interaction logic for TimeLineControl.xaml
    /// </summary>
    public partial class TimeLineControl : UserControl
    {
        public TimeLineControl()
        {
            InitializeComponent();

            AddNewQuestionLine(0, "Створення світу");

            AddNewTimeInterval(1);

            AddNewQuestionLine(2, "Народження Христа");

            AddNewTimeInterval(3);

            AddNewQuestionLine(4, "Вознесіння");
        }

        private void AddNewTimeInterval(int rowNumber)
        {
            TimeIntervalControl timeInterval;
            timeLineControlContainer.RowDefinitions.Add(new RowDefinition());
            timeInterval = new TimeIntervalControl();
            Grid.SetRow(timeInterval, rowNumber);
            timeInterval.Margin = new Thickness(0, -15, 0, -15);
            timeInterval.HorizontalAlignment = HorizontalAlignment.Left;
            timeLineControlContainer.Children.Add(timeInterval);
        }

        private void AddNewQuestionLine(int rowNumber, string question)
        {
            timeLineControlContainer.RowDefinitions.Add(new RowDefinition());

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            Line line = new Line();
            line.Height = 2;
            line.StrokeThickness = 2;
            line.Width = this.Width / 4;
            line.X2 = this.Width / 4;
            line.Stroke = Brushes.White;

            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 24;
            textBlock.Margin = new Thickness(15, 0, 0, 0);
            textBlock.VerticalAlignment = VerticalAlignment.Top;
            textBlock.FontWeight = FontWeights.DemiBold;
            textBlock.Foreground = Brushes.White;
            textBlock.Text = question;

            stackPanel.Children.Add(line);
            stackPanel.Children.Add(textBlock);

            Grid.SetRow(stackPanel, rowNumber);
            timeLineControlContainer.Children.Add(stackPanel);
        }
    }
}
