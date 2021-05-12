﻿using System;
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

        public static int testInt1;
        public static int testInt2;
        public  GUI()
        {
            DataContext = new GUItools();
            InitializeComponent();
            
        }





        public WindowState WindowState { get; private set; }

        private void _minimize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;

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
        public static string durchmesser;
        public static string material;
        public static string schraubenart;
        public static string festigkeit;
        public static string kopfform;
        public static string schraubenlänge;
        public static string gewindelänge;

        private void btn_berechnen_Click(object sender, RoutedEventArgs e)

        {
            //eingaben werden übergeben
            durchmesser = cb_durchmesser.Text;
            material = cb_material.Text;
            schraubenart = cb_schraubenart.Text;
            festigkeit = cb_festigkeit.Text;
            kopfform = cb_kopfform.Text;
            schraubenlänge = tbx_schraubenlänge.Text;
            gewindelänge = tbx_schraubenlänge.Text;

            new ExcelControl();
            //ausgaben werden geholt
            tb_durchmesser.Text = Convert.ToString(ExcelControl.Durchmesser);
            tb_flankendurchmesser.Text = Convert.ToString(ExcelControl.Flankendurchmesser);
            tb_gesamtmasse .Text = Convert.ToString(ExcelControl.Gesamtmasse);
            tb_kerndurchmesser.Text = Convert.ToString(ExcelControl.Kerndurchmesser);
            tb_kernlochdurchmesser.Text = Convert.ToString(ExcelControl.Kernlochdurchmesser);
            tb_preisInEuro.Text = Convert.ToString(ExcelControl.Preis);
            tb_schlüsselweite.Text = Convert.ToString(ExcelControl.SW);
            tb_streckgrenze.Text = ExcelControl.Re;
            tb_zugfestigkeit.Text = ExcelControl.Rm;
            tb_ftm.Text = Convert.ToString(ExcelControl.FTM);
            tb_steigung.Text = Convert.ToString(ExcelControl.Steigung);


        }

        private void cb_durch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_kopfform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_kopfform.SelectedIndex == 0)
            {
                img_SechskantSchraube.Visibility = Visibility.Visible;
                img_SenkkopfSchraube.Visibility = Visibility.Hidden;
                img_ZylinderkopfSchraube.Visibility = Visibility.Hidden;
            }
            else if (cb_kopfform.SelectedIndex == 2)
            {
                img_SenkkopfSchraube.Visibility = Visibility.Visible;
                img_SechskantSchraube.Visibility = Visibility.Hidden;
                img_ZylinderkopfSchraube.Visibility = Visibility.Hidden;
            }

            else if (cb_kopfform.SelectedIndex == 1)
            {
                img_ZylinderkopfSchraube.Visibility = Visibility.Visible;
                img_SechskantSchraube.Visibility = Visibility.Hidden;
                img_SenkkopfSchraube.Visibility = Visibility.Hidden;
            }

            else
            {
                img_ZylinderkopfSchraube.Visibility = Visibility.Hidden;
                img_SechskantSchraube.Visibility = Visibility.Hidden;
                img_SenkkopfSchraube.Visibility = Visibility.Hidden;
            }

        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            cb_durchmesser.SelectedItem = "";
            cb_festigkeit.SelectedItem = "";
            cb_schraubenart.SelectedItem = "";
            cb_kopfform.SelectedItem = "";
            cb_material.SelectedItem = "";
            tbx_gewindelänge.Text = "";
            tbx_schraubenlänge.Text = "";
            img_SechskantSchraube.Visibility = Visibility.Hidden;
            img_SenkkopfSchraube.Visibility = Visibility.Hidden;
            img_ZylinderkopfSchraube.Visibility = Visibility.Hidden;
        }

        private void tbx_schraubenlänge_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(tbx_schraubenlänge.Text, out testInt1) && testInt1 >= 5 && testInt1 <= 1000 && testInt1 >= testInt2)
            {
                tbx_schraubenlänge.Background = Brushes.White;

            }

            else if (tbx_schraubenlänge.Text == "" ) 
            {
                tbx_schraubenlänge.Background = Brushes.White;
            }

            else
            {
                tbx_schraubenlänge.Background = Brushes.Red;
            }

        }

        private void tbx_gewindelänge_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbx_gewindelänge.Text, out testInt2) && testInt2 >=5 && testInt2 <=1000 && testInt2 <= testInt1)
            {
                tbx_gewindelänge.Background = Brushes.White;

            }

            else if (tbx_gewindelänge.Text == "")
            {
                tbx_gewindelänge.Background = Brushes.White;
            }

            else
            {
                tbx_gewindelänge.Background = Brushes.Red;
            }
        }
    }


}
