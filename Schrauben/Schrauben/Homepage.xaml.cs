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

namespace Schrauben
{
    /// <summary>
    /// Interaktionslogik für Homepage.xaml
    /// </summary>
    public partial class KonfigGUI : UserControl
    {
        public KonfigGUI()
        {
            InitializeComponent();
        }

        private void Button_Konfig(object sender, RoutedEventArgs e)
        {
            GUI home = new GUI();
            this.Content = home;
            
        }

    }
}
