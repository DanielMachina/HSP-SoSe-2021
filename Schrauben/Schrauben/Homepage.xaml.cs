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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GUI home = new GUI();
            this.Content = home;
            
        }

        private void Button_Impressum(object sender, RoutedEventArgs e)
        {
            GUI impressum = new GUI();
            this.Content = impressum;

        }

        private void Button_Kontakt(object sender, RoutedEventArgs e)
        {
            GUI kontakt = new GUI();
            this.Content = kontakt;

        }

    }
}
