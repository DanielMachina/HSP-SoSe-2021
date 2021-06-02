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
        bool permission = false;
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
        public static string Variante1;
        public static string Variante2;

        public GUI()
        {
            DataContext = new GUItools();
            InitializeComponent();

        }



        #region TopBar
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

        #endregion 


        #region Berechnen
        private void btn_berechnen_Click(object sender, RoutedEventArgs e)

        {
            // Bedingung für Berechnung
            if (cb_schraubenart.Text == "Metrisch" && cb_MetDurchmesser.Text != String.Empty)
            {
                Variante1 = "gut";
            }
            else if (cb_schraubenart.Text == "Metrisch" && cb_MetDurchmesser.Text == String.Empty)
            {
                Variante1 = "schlecht";
            }

            if (cb_schraubenart.Text == "Metrisch_Fein" && cb_fMetDurchmesser.Text != String.Empty)
            {
                Variante1 = "gut";
            }
            else if (cb_schraubenart.Text == "Metrisch_Fein" && cb_fMetDurchmesser.Text == String.Empty)
            {
                Variante1 = "schlecht";
            }

            if (cb_schraubenart.Text == "Zoll" && cb_ZollDurchmesser.Text != String.Empty)
            {
                Variante1 = "gut";
            }
            else if (cb_schraubenart.Text == "Zoll" && cb_ZollDurchmesser.Text == String.Empty)
            {
                Variante1 = "schlecht";
            }

            if (Farbe1 == "Grün" && Farbe2 == "Grün" && cb_festigkeit.Text != String.Empty && cb_schraubenart.Text != String.Empty &&
                    cb_kopfform.Text != String.Empty && cb_material.Text != String.Empty && Variante1 == "gut")

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
                tb_durchmesser.Visibility = Visibility.Visible;
                tb_steigung.Visibility = Visibility.Visible;
                tb_flankendurchmesser.Visibility = Visibility.Visible;
                tb_kerndurchmesser.Visibility = Visibility.Visible;
                tb_kernlochdurchmesser.Visibility = Visibility.Visible;
                tb_gesamtmasse.Visibility = Visibility.Visible;
                tb_schlüsselweite.Visibility = Visibility.Visible;
                tb_streckgrenze.Visibility = Visibility.Visible;
                tb_zugfestigkeit.Visibility = Visibility.Visible;
                tb_preisInEuro.Visibility = Visibility.Visible;
                tb_ftm.Visibility = Visibility.Visible;

                tb_durchmesser.Text = Convert.ToString(ExcelControl.Durchmesser + "mm");
                tb_flankendurchmesser.Text = Convert.ToString(ExcelControl.Flankendurchmesser + "mm");
                tb_gesamtmasse.Text = Convert.ToString(ExcelControl.Gesamtmasse + "kg");
                tb_kerndurchmesser.Text = Convert.ToString(ExcelControl.Kerndurchmesser + "mm");
                tb_kernlochdurchmesser.Text = Convert.ToString(ExcelControl.Kernlochdurchmesser + "mm");
                tb_preisInEuro.Text = Convert.ToString(ExcelControl.Preis + " €");
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

                permission = true;
                btn_drucken.Foreground = Brushes.Black;
                btn_cad.Foreground = Brushes.Black;
            }

            else
            {
                MessageBox.Show("Angegebene Schraubenparameter NICHT gültig!");
            }



        }
        #endregion

        #region Schraubenart
        private void cb_schraubenart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_fMetDurchmesser == null || cb_ZollDurchmesser == null || cb_MetDurchmesser == null || cb_schraubenart.SelectedItem == null )
            { return; }




            if (cb_schraubenart.SelectedItem.ToString() == "Metrisch")
            {
                HideCbDurch(cb_MetDurchmesser);
                cb_MetDurchmesser.SelectedIndex = 0;
            }

            else if (cb_schraubenart.SelectedItem.ToString() == "Zoll")
            {
                HideCbDurch(cb_ZollDurchmesser);
                cb_ZollDurchmesser.SelectedIndex = 0;
            }


            else if (cb_schraubenart.SelectedItem.ToString() == "Metrisch_Fein")
            {
                HideCbDurch(cb_fMetDurchmesser);
                cb_fMetDurchmesser.SelectedIndex = 0;
            }
            permission = false;


        }
        #endregion

        #region Kopfform
        private void cb_kopfform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cb_kopfform == null)
            { return; }

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

            permission = false;

        }
        #endregion

        #region ComboBoxAuswahl
        private void HideCbDurch(ComboBox CbShow)
        {
            cb_fMetDurchmesser.Visibility = Visibility.Hidden;
            cb_MetDurchmesser.Visibility = Visibility.Hidden;
            cb_ZollDurchmesser.Visibility = Visibility.Hidden;

            CbShow.Visibility = Visibility.Visible;
        }

        #endregion

        #region Schraubenlänge
        private void tbx_schraubenlänge_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (tbx_schraubenlänge == null)
            { return; }

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


            permission = false;
        }
        #endregion

        #region Gewindelänge
        private void tbx_gewindelänge_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbx_gewindelänge == null)
            { return; }

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

            permission = false;
        }
        #endregion

        #region Slider-Menge
        private void sl_menge_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sl_menge == null)
            { return; }

            tbx_menge.Text = Convert.ToString(sl_menge.Value);
            permission = false;
        }

        private void tbx_menge_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (tbx_menge == null)
            { return; }

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

            permission = false;
        }

        #endregion

        #region CAD
        

        private void btn_cad_Click(object sender, RoutedEventArgs e)
        {
            if (permission == true)
            {
                new CatiaControl();
            }
            else
            {
                btn_cad.Foreground = Brushes.Red;
            }

        }



        
        #endregion

        #region Drucken
        private void btn_drucken_Click(object sender, RoutedEventArgs e)
        {
            if (permission == true)
            {
                new Ausdrucken();
            }
            else
            {
                btn_drucken.Foreground = Brushes.Red;
                lb_Info.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region RadioButton

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
        #endregion

        #region FestigkeitsBedingungen


        private void cb_material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //wenn die Festigkeiten noch nicht compiled sind, verlässt das Programm die Methode 
            if (cb_festigkeitTit == null || cb_festigkeitMesBron == null || cb_festigkeitKup == null || cb_festigkeit == null || cb_festigkeitAlu == null)
            { return; }

            //Abfragen welches Material ausgewählt ist

            if (cb_material.SelectedItem is "Stahl")
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

            permission = false;

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

        #region Festigkeiten
        private void cb_festigkeit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permission = false;
        }

        private void cb_festigkeitAlu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permission = false;
        }

        private void cb_festigkeitTit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permission = false;
        }

        private void cb_festigkeitKup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permission = false;
        }

        private void cb_festigkeitMesBron_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permission = false;
        }

        #endregion

        #region MetrischerDurchmesser
        private void cb_MetDurchmesser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //wenn cb nicht existiert, soll returned werden um keinen Fehler zu bekommen
            if (cb_MetDurchmesser == null || tbx_schraubenlänge == null)
            { return; }


            //Keine Druckerlaubnis/Cad-Erlaubnis geben
            permission = false;
        }
        #endregion

        #region MetrischFeinDurchmesser
        private void cb_fMetDurchmesser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            permission = false;
        }

        #endregion

        #region ZollDurchmesser

        private void cb_ZollDurchmesser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            permission = false;
        }

        #endregion

    }



}
