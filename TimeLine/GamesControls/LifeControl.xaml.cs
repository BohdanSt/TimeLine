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
    /// Логика взаимодействия для LifeControl.xaml
    /// </summary>
    public partial class LifeControl : UserControl
    {
        bool status = true;
        public LifeControl()
        {
            InitializeComponent();
        }
        public bool GetStatus()
        {
            return status;
        }
        public void Fail()
        {
            status = false;
        }

    }
}
