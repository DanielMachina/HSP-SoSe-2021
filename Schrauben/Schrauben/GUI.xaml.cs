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
        public static bool off = false;
        public static int testInt1;
        public static int testInt2;
        public static int testInt3;
        public static bool aus = false;

        public GUI()
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
        public static string menge;
        public static string Drehsinn;
        public static string SW;
        public static string Darstellung;
        public static string Farbe1;
        public static string Farbe2;


        private void btn_berechnen_Click(object sender, RoutedEventArgs e)

        {
            if (Farbe1 == "Grün" && Farbe2 == "Grün" && cb_MetDurchmesser.Text != String.Empty && cb_festigkeit.Text != String.Empty && cb_schraubenart.Text != String.Empty &&
                    cb_kopfform.Text != String.Empty && cb_material.Text != String.Empty && tbx_gewindelänge.Text != String.Empty && tbx_schraubenlänge.Text != String.Empty)
            {
                //eingaben werden übergeben


                if (cb_MetDurchmesser.IsVisible)
                {
                    durchmesser = (string)cb_MetDurchmesser.SelectedItem;
                }

                if (cb_fMetDurchmesser.IsVisible)
                {
                    durchmesser = (string)cb_fMetDurchmesser.SelectedItem;
                }

                if (cb_ZollDurchmesser.IsVisible)
                {
                    durchmesser = (string)cb_ZollDurchmesser.SelectedItem;
                }

                material = (string)cb_material.SelectedItem;
                schraubenart = (string)cb_schraubenart.SelectedItem;
                festigkeit = (string)cb_festigkeit.SelectedItem;
                kopfform = (string)cb_kopfform.SelectedItem;
                schraubenlänge = tbx_schraubenlänge.Text;
                gewindelänge = tbx_gewindelänge.Text;
                menge = tbx_menge.Text;


                ExcelControl XL = new ExcelControl();

                //XL.XlSchreiben();

                //XL.XlLesen();
                //ausgaben werden geholt
                tb_durchmesser.Text = Convert.ToString(ExcelControl.Durchmesser + "mm");
                tb_flankendurchmesser.Text = Convert.ToString(ExcelControl.Flankendurchmesser + "mm");
                tb_gesamtmasse.Text = Convert.ToString(ExcelControl.Gesamtmasse + "kg");
                tb_kerndurchmesser.Text = Convert.ToString(ExcelControl.Kerndurchmesser + "mm");
                tb_kernlochdurchmesser.Text = Convert.ToString(ExcelControl.Kernlochdurchmesser + "mm");
                tb_preisInEuro.Text = Convert.ToString(ExcelControl.Preis + "EUR");
                if (ExcelControl.SWZ == "0")
                {
                    SW = tb_schlüsselweite.Text = Convert.ToString(ExcelControl.SWM);
                }
                else if (ExcelControl.SWZ != "0")
                {
                    SW = tb_schlüsselweite.Text = ExcelControl.SWZ + "''";
                }
                tb_streckgrenze.Text = ExcelControl.Re + "N/mm^2";
                tb_zugfestigkeit.Text = ExcelControl.Rm + "N/mm^2";
                tb_ftm.Text = Convert.ToString(ExcelControl.FTM + "mm^4");
                tb_steigung.Text = Convert.ToString(ExcelControl.Steigung + "mm");
            }

            else
            {
                MessageBox.Show("Angegebene Schraubenparameter NICHT gültig!");
            }



        }



        private void cb_schraubenart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_fMetDurchmesser == null || cb_ZollDurchmesser == null || cb_MetDurchmesser == null ||cb_schraubenart.SelectedItem == null)
            { return; }




            if (cb_schraubenart.SelectedItem.ToString() == "Metrisch")
            {
                cb_fMetDurchmesser.Visibility = Visibility.Hidden;
                cb_ZollDurchmesser.Visibility = Visibility.Hidden;
                cb_MetDurchmesser.Visibility = Visibility.Visible;

            }

            if (cb_schraubenart.SelectedItem.ToString() == "Zoll")
            {
                cb_fMetDurchmesser.Visibility = Visibility.Hidden;
                cb_MetDurchmesser.Visibility = Visibility.Hidden;
                cb_ZollDurchmesser.Visibility = Visibility.Visible;
            }

            if (cb_schraubenart.SelectedItem.ToString() == "Metrisch_Fein")
            {
                cb_ZollDurchmesser.Visibility = Visibility.Hidden;
                cb_MetDurchmesser.Visibility = Visibility.Hidden;
                cb_fMetDurchmesser.Visibility = Visibility.Visible;
            }
              



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
            cb_MetDurchmesser.Text = String.Empty;
            cb_festigkeit.Text = String.Empty;
            cb_schraubenart.Text = String.Empty;
            cb_kopfform.Text = String.Empty;
            cb_material.Text = String.Empty;
            tbx_gewindelänge.Text = String.Empty;
            tbx_schraubenlänge.Text = String.Empty;
            tbx_menge.Text = "1";

            img_SechskantSchraube.Visibility = Visibility.Hidden;
            img_SenkkopfSchraube.Visibility = Visibility.Hidden;
            img_ZylinderkopfSchraube.Visibility = Visibility.Hidden;
        }

        private void tbx_schraubenlänge_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(tbx_schraubenlänge.Text, out testInt1) && testInt1 >= 5 && testInt1 <= 1000 && testInt1 >= testInt2)
            {
                tbx_schraubenlänge.Background = Brushes.White;
                Farbe1 = "Grün";
            }

            else if (tbx_schraubenlänge.Text == "")
            {
                tbx_schraubenlänge.Background = Brushes.White;
                Farbe1 = "Rot";
            }

            else
            {
                tbx_schraubenlänge.Background = Brushes.Red;
                Farbe1 = "Rot";
            }


        }

        private void tbx_gewindelänge_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbx_gewindelänge.Text, out testInt2) && testInt2 >= 5 && testInt2 <= 1000 && testInt2 <= testInt1)
            {
                tbx_gewindelänge.Background = Brushes.White;
                Farbe2 = "Grün";
            }

            else if (tbx_gewindelänge.Text == "")
            {
                tbx_gewindelänge.Background = Brushes.White;
                Farbe2 = "Rot";
            }

            else
            {
                tbx_gewindelänge.Background = Brushes.Red;
                Farbe2 = "Rot";
            }
        }

        private void sl_menge_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbx_menge.Text = Convert.ToString(sl_menge.Value);
        }

        private void tbx_menge_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbx_menge.Text == "")
            {
                tbx_menge.Text = "1";
            }

            if (int.TryParse(tbx_menge.Text, out testInt3) && testInt3 >= 1 && testInt3 <= 1000)
            {
                tbx_menge.Background = Brushes.White;
                sl_menge.Value = Convert.ToDouble(tbx_menge.Text);

            }
            else
            {
                tbx_menge.Background = Brushes.Red;
            }

        }

        private void btn_cad_Click(object sender, RoutedEventArgs e)
        {
            new CatiaControl();
        }

        private void btn_drucken_Click(object sender, RoutedEventArgs e)
        {
            new Ausdrucken();
        }

        private void rb_links(object sender, RoutedEventArgs e)
        {
            Drehsinn = "links";
        }

        private void rb_rechts(object sender, RoutedEventArgs e)
        {
            Drehsinn = "rechts";
        }

        private void rb_optisch(object sender, RoutedEventArgs e)
        {
            Darstellung = "optisch";
        }

        private void rb_technisch(object sender, RoutedEventArgs e)
        {
            Darstellung = "technisch";
        }


        #region FestigkeitsBedingungen

        
        private void cb_material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //wenn die Festigkeiten noch nicht compiled sind, verlässt das Programm die Methode 
            if (cb_festigkeitTit == null|| cb_festigkeitMesBron == null || cb_festigkeitKup == null || cb_festigkeit == null|| cb_festigkeitAlu == null)
            { return; }

            //Abfragen welches Material ausgewählt ist

            if(cb_material.SelectedItem is "Stahl")
            {
                FestVis(cb_festigkeit);
            }

            if (cb_material.SelectedItem is "Aluminium")
            {
                FestVis(cb_festigkeitAlu);
            }

            if (cb_material.SelectedItem is "Kupfer")
            {
                FestVis(cb_festigkeitKup);
            }

            if (cb_material.SelectedItem is "Messing" || cb_material.SelectedItem is "Bronze")
            {
                FestVis(cb_festigkeitMesBron);
            }

            if (cb_material.SelectedItem is "Titan")
            {
                FestVis(cb_festigkeitTit);
            }

        }

        //nicht benötigte ComboBoxen werden versteckt
        private void FestVis(ComboBox cb_name)
        {
            cb_festigkeitTit.Visibility = Visibility.Hidden;
            cb_festigkeitMesBron.Visibility = Visibility.Hidden;
            cb_festigkeitKup.Visibility = Visibility.Hidden;
            cb_festigkeitAlu.Visibility = Visibility.Hidden;
            cb_festigkeit.Visibility = Visibility.Hidden;

            cb_name.Visibility = Visibility.Visible;
        }
        #endregion
    }



}
