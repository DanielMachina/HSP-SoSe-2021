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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class GUI : UserControl
    {
        public GUI()
        {
            DataContext = new Tools();
            InitializeComponent();
        }

        public WindowState WindowState { get; private set; }

        private void _minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void _exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Zurück_Click(object sender, RoutedEventArgs e)
        {
            KonfigGUI home = new KonfigGUI();
            this.Content = home;

        }
    }
}
