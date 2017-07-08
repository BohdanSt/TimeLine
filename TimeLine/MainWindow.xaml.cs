using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace TimeLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            gamesRules.StartGame += StartGame;
            gamesControl.EndGame += EndGame;
        }

        private void EndGame(int counter, int currentAmountOfLife)
        {
            ShowGamesResult();
        }

        private void StartGame()
        {
            ShowGameControl();

            gamesControl.StartGame();
        }

        private void ShowGameControl()
        {
            gamesRules.Opacity = 1;
            gamesControl.Opacity = 0;
            gamesControl.Visibility = Visibility.Visible;

            for (int i = 0; i < 50; i++)
            {
                gamesRules.Opacity -= 0.02;
                gamesControl.Opacity += 0.02;

                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
                Thread.Sleep(25);
                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
            }

            gamesRules.Visibility = Visibility.Collapsed;
            gamesRules.Opacity = 1;
        }

        private void ShowGamesResult()
        {
            gamesControl.Opacity = 1;
            gamesResult.Opacity = 0;
            gamesResult.Visibility = Visibility.Visible;

            for (int i = 0; i < 50; i++)
            {
                gamesControl.Opacity -= 0.02;
                gamesResult.Opacity += 0.02;

                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
                Thread.Sleep(25);
                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
            }

            gamesControl.Visibility = Visibility.Collapsed;
            gamesControl.Opacity = 1;
        }
    }
}
