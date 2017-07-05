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

namespace TimeLine.GamesControls
{
    /// <summary>
    /// Логика взаимодействия для LifeControl.xaml
    /// </summary>
    public partial class LifeControl : UserControl
    {
        private bool isActive;

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                if (value)
                {
                    ActivateControl();
                }
                else
                {
                    DisactivateControl();
                }
            }
        }

        public LifeControl()
        {
            InitializeComponent();

            IsActive = true;
        }

        void ActivateControl()
        {
            imageDisactiveLife.Opacity = 1;
            imageActiveLife.Opacity = 0;
            imageActiveLife.Visibility = Visibility.Visible;

            for (int i = 0; i < 50; i++)
            {
                imageDisactiveLife.Opacity -= 0.02;
                imageActiveLife.Opacity += 0.02;

                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
                Thread.Sleep(25);
                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
            }

            imageDisactiveLife.Visibility = Visibility.Collapsed;
            imageDisactiveLife.Opacity = 1;
        }

        void DisactivateControl()
        {
            imageActiveLife.Opacity = 1;
            imageDisactiveLife.Opacity = 0;
            imageDisactiveLife.Visibility = Visibility.Visible;

            for (int i = 0; i < 50; i++)
            {
                imageActiveLife.Opacity -= 0.02;
                imageDisactiveLife.Opacity += 0.02;

                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
                Thread.Sleep(25);
                Dispatcher.Invoke(DispatcherPriority.Render, (Action)(() => { }));
            }

            imageActiveLife.Visibility = Visibility.Collapsed;
            imageActiveLife.Opacity = 1;
        }
    }
}
