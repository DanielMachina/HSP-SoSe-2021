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


            Homepage.Title = "SchraubenGmbH/Homepage";
            Homepage.ResizeMode = ResizeMode.CanMinimize;
            Homepage.Content = HomeGUI;
            Homepage.Width = 900;
            Homepage.Height = 500;
            Homepage.WindowStyle = WindowStyle.None;
            Homepage.AllowsTransparency = true;
            Homepage.Background = Brushes.Transparent;


            Konfig.Title = "Schraubenkonfigurator";
            Konfig.ResizeMode = ResizeMode.CanMinimize;
            Konfig.Content = SchraubenGUI;
            Konfig.WindowStyle = WindowStyle.None;
            Konfig.AllowsTransparency = true;
            Konfig.Background = Brushes.Transparent;
            Konfig.Width = 900;
            Konfig.Height = 500;

            Homepage.ShowDialog();
            //Konfig.ShowDialog();
            //Console.ReadKey();
        }

        [STAThread]
        public static void Main()
        {
            new MainSchraube();
            new ExcelControl();
            string antwort;
            Schraubendefinition eins = new Schraubendefinition();
            Tools tool = new Tools();
            //Eingabe Material
            do
            {
                tool.Abfrage("Material" , "Stahl, Aluminium, Messing, Kupfer und Titan");
                eins.getMaterial();
            } while (eins.beenden != true);


            //Eingabe Schraubenart
            do
            {
                tool.Abfrage("Schraubenart", "Metrisch, Metrisch Fein, Zoll - gewinde");
                Console.ForegroundColor = ConsoleColor.Green;
                eins.Art = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("");  

                tool.Ausgabe_Gewinde(eins);
                if (eins.Durchmesser == 0)
                {

                    Console.WriteLine(eins.wiederholung);
                    Console.ForegroundColor = ConsoleColor.Green;
                    antwort = Console.ReadLine().Trim().ToLower();
                    Console.ResetColor();
                    if (antwort != "ja")
                    { Environment.Exit(0); }

                }
                else { break; }

            } while (true);




            //Eingabe Laenge

            do
            {

                tool.Abfrage("Länge in mm", "10-1000mm");
                Console.ForegroundColor = ConsoleColor.Green;
                eins.Laenge = Convert.ToDouble(Console.ReadLine());
                Console.ResetColor();
                if (eins.Laenge < 10 || eins.Laenge > 1000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Schraube leider außerhalb des möglichen Maßes");
                    Console.ResetColor();
                    Console.WriteLine(eins.wiederholung);
                    Console.ForegroundColor = ConsoleColor.Green;
                    antwort = Console.ReadLine().Trim().ToLower();
                    Console.ResetColor();
                    if (antwort != "ja")
                    {
                        Environment.Exit(0);
                    }

                }
                else
                { break; }


            }
            while (true);

            {

            }
            Console.WriteLine("");

            //Eingabe Schraubenkopf
            do
            {
                tool.Abfrage("Schraubenkopf", "Sechskant, Zylindrisch und Senkkopf");

                eins.Schraubenkopf();
                if(eins.Schlüsselweite == 0)
                {
                    Console.WriteLine(eins.wiederholung);
                    Console.ForegroundColor = ConsoleColor.Green;
                    antwort = Console.ReadLine().Trim().ToLower();
                    Console.ResetColor();
                    if (antwort == "nein")
                    {
                        Environment.Exit(0);
                    }

                }
                else { break; }
            } while (true);
            //Berechnung Volumen

            eins.Volumen = eins.Laenge * Math.Pow(eins.Durchmesser, 2) * (Math.PI / 4);

            //Berechnung Masse, Ausgabe Masse
            eins.Masse = eins.getDichte(eins.Material) * eins.Volumen / 1000; 
            Console.WriteLine($"Die Masse ist {eins.Masse} Gramm");
            Console.WriteLine("");

            //Mengeneingabe und Gesamtgewicht
            tool.Abfrage("Menge", "");
            Console.ForegroundColor = ConsoleColor.Green;
            eins.Menge = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("");
            eins.Gesamtmasse = eins.Masse * eins.Menge; //Gesamtgewicht aus Einzelmasse und Menge
            Console.WriteLine($"Die Gesamtmasse ist {eins.Gesamtmasse/1000} Kilogramm");

            Console.ReadKey();
        }
    }



 
   
}
