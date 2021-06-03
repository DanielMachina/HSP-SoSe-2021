using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Schrauben
{
    public class MainSchraube
    {
        public MainSchraube ()
        {

            KonfigGUI HomeGUI = new KonfigGUI();
            GUI SchraubenGUI = new GUI();

            Window Homepage = new Window();
            Window Konfig = new Window();

            #region Homepage
            Homepage.Title = "Schrauben";
            Homepage.ResizeMode = ResizeMode.CanMinimize;
            Homepage.Content = HomeGUI;
            Homepage.Width = 900;
            Homepage.Height = 500;
            Homepage.WindowStyle = WindowStyle.None;
            Homepage.AllowsTransparency = true;
            Homepage.Background = Brushes.Transparent;
            Homepage.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            #endregion

            #region Konfig
            Konfig.Title = "Schraubenkonfigurator";
            Konfig.ResizeMode = ResizeMode.CanMinimize;
            Konfig.Content = SchraubenGUI;
            Konfig.WindowStyle = WindowStyle.None;
            Konfig.AllowsTransparency = true;
            Konfig.Background = Brushes.Transparent;
            Konfig.Width = 900;
            Konfig.Height = 500;
            Konfig.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            #endregion


            Homepage.ShowDialog();
        }

        [STAThread]
        public static void Main()
        {
            new MainSchraube();
        }


    }



 
   
}
