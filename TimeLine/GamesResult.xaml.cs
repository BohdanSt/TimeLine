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

namespace TimeLine
{
    /// <summary>
    /// Interaction logic for GamesResult.xaml
    /// </summary>
    public partial class GamesResult : UserControl
    {
        List<string> YourLevel = new List<string>
        {
            "Адам і Єва",
            "Падший ангел",
            "Ангел",
            "Архангел",
            "Серафім і Херувім",
            "Біблеїст",
            "-----"
        };
        public GamesResult()
        {
            InitializeComponent();
            
        }
    }
}
