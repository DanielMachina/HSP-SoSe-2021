using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{
    class Program
    {

        public static void Main()
        {          
            Schraubendefinition eins = new Schraubendefinition();
            //Eingabe Material
            do
            {
                eins.MaterialAbfrage();
            }
            while (eins.beenden != true);


            //Eingabe Schraubenart
            Console.WriteLine("Bitte geben Sie Ihren gewünschten Schraubenart an. Es gibt Metrisch, Metrisch Fein, Zoll, Trapez, Rohr - gewinde und Holzschrauben zur Auswahl.");
            eins.Art = Convert.ToString(Console.ReadLine());
            //Ausgabe Durchmesser und Steigung
            //eins.Ausgabe_Gewinde(eins);

            //Eingabe Schraubenkopf
            Console.WriteLine("Bitte gewünschte Schraubenkopf eingeben. Es stehen Sechskant, Zylindrisch und Senkkopf zur Verfügung.");
            eins.Kopf = Convert.ToString(Console.ReadLine());

            //Eingabe Durchmesser
            //Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von M1 bis M42 Schrauben zur Auswahl.");
            //eins.Gewinde = Convert.ToString(Console.ReadLine());           
            //Ausgabe Durchmesser und Steigung
            //eins.Ausgabe_Gewinde(eins);

            Console.ReadKey();

        }
    }

    public class Schraubendefinition
    {
        Program zwei = new Program();

        public bool beenden;
        public string Material 
        { get; set; }
        public string Art
        { get; set; }
        public string Gewinde 
        { get; set; }
        public string Gewinde_Fein 
        { get; set; }
        public string Gewinde_Zoll 
        { get; set; }
        public string Gewinde_Rohr 
        { get; set; }
        public string Gewinde_Trapez
        { get; set; }
        public string Gewinde_Holz
        { get; set; }
        public string Kopf 
        { get; set; }


        public bool MaterialAbfrage()
        {
            string abfrage = "Nochmal versuchen? (ja/nein)";
            Console.WriteLine("Bitte gewünschtes Material eingeben. Es stehen Stahl, Aluminium, Messing, Kupfer und Titan zur Verfügung.");
            Material = Convert.ToString(Console.ReadLine());
            //Ausgabe Material
            if (getDichte(Material) == 0)
            {
                Console.WriteLine(abfrage);
                string antwort = Console.ReadLine().Trim().ToLower();
                if (antwort != "ja")
                {

                    beenden = true;
                }
                

            }
            else
            {
                beenden = true;
            }

            return beenden;
        }



        public void Ausgabe_Gewinde(Schraubendefinition eins)
        {
            var zahlen = eins.getDurchmesser();
            Console.WriteLine($"Der Durchmesser ist {zahlen._durchmesser}");
            Console.WriteLine($"Die Steigung ist {zahlen._steigung}");
            Console.WriteLine($"Der Kernlochdurchmesser ist {zahlen._kernloch}");
            Console.WriteLine($"Der Kerndurchmesser ist {zahlen._kern}");
            Console.WriteLine($"Der Flankendurchmesser ist {zahlen._flanken}");
        }

        public double getDichte(string material) // Methode um Dichte des jeweiligen Materials zu bekommen
        {
            double spezDichte=0;
                switch (Material)
                {
                    case "Stahl": 
                        spezDichte = 7.85; // Hier bekommt  das Material seine Dichte
                        break;
                    case "Aluminium":
                        spezDichte = 2.7;
                        break;
                    case "Titan":
                        spezDichte = 4.507;
                        break;
                    case "Messing":
                        spezDichte = 8.73;
                        break;
                    case "Kupfer":
                        spezDichte = 8.96;
                        break;

                default: // Falls ein nicht aufgelistetes Material benutzt wird wird default ausgegeben
                    Console.WriteLine("Material leider nicht vorhanden, prüfe deine Rechtschreibung: " + Material);

                        break;
                }
           
            
                return spezDichte;
        }

        public static void Schraubenart(string Art) // Methode um Art/Variante der Schraube zu klären
        {
            Schraubendefinition eins = new Schraubendefinition();
            
            switch (Art)
            {
                case "Metrisch":
                    Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von M1 bis M42 Schrauben zur Auswahl.");
                    eins.Gewinde = Convert.ToString(Console.ReadLine());
                    break;
                case "Metrisch Fein":
                    Console.WriteLine("Bitte geben Sie eine genormtes Feingewinde ein. Z.B.: M8x0,25 ");
                    eins.Gewinde_Fein = Convert.ToString(Console.ReadLine());                    
                    break;
                case "Zoll":
                    //   Gewinde_Zoll;
                    break;
                case "Rohr":
                 //   Gewinde_Rohr;
                    break;
                case "Holz":
                  //  Gewinde_Holz;
                    break;
                case "Trapez":
                 //   Gewinde_Trapez
                    break;

                default: // Falls eine nicht aufgelistete Art benutzt wird wird default ausgegeben
                    Console.WriteLine("Schraubenart leider nicht vorhanden, prüfe deine Rechtschreibung: " + Art);
                    break;
            }
            eins.Ausgabe_Gewinde(eins);
        }

        public static void Schraubenkopf(string Kopf) //Methode um Schraubenkopf zu wählen.
        {
            Schraubendefinition eins = new Schraubendefinition();

            switch (Kopf)
            {
                case "Sechskant":
                    break;

                case "Zylindrisch":
                    break;

                case "Senkkopf":
                    break;

                default:
                    Console.WriteLine("Schraubenkopf leider nicht vorhanden, prüfe Rechtschreibung " + Kopf);
                    break;
            }

        }
        public (double _durchmesser, double _steigung, double _kernloch, double _kern, double _flanken) getDurchmesser() // Methode um den Durchmesser der jeweiligen Gewindegröße zu bekommen
        {
            double spezDurchmesser = 0;
            double spezFlankendurchmesser;
            double spezKerndurchmesser;
            double spezKernlochdurchmesser;
            double spezSteigung = 0 ;

            switch (Gewinde)
            {
                case "M1": 
                    spezDurchmesser = 1; // Hier bekommt  das Gewinde seinen Durchmesser
                    spezSteigung = 0.25;                    
                    break;
                case "M1,2":
                    spezDurchmesser = 1.2;
                    spezSteigung = 0.25;
                    break;
                case "M1,6":
                    spezDurchmesser = 1.6;
                    spezSteigung = 0.35;
                    break;
                case "M2":
                    spezDurchmesser = 2;
                    spezSteigung = 0.4;
                    break;
                case "M2,5":
                    spezDurchmesser = 2.5;
                    spezSteigung = 0.45;
                    break;
                case "M3":
                    spezDurchmesser = 3;
                    spezSteigung = 0.5;
                    break;
                case "M4":
                    spezDurchmesser = 4;
                    spezSteigung = 0.7;
                    break;
                case "M5":
                    spezDurchmesser = 5;
                    spezSteigung = 0.8;
                    break;
                case "M6":
                    spezDurchmesser = 6;
                    spezSteigung = 1;
                    break;
                case "M8":
                    spezDurchmesser = 8;
                    spezSteigung = 1.25;
                    break;
                case "M10":
                    spezDurchmesser = 10;
                    spezSteigung = 1.5;
                    break;
                case "M12":
                    spezDurchmesser = 12;
                    spezSteigung = 1.75;
                    break;
                case "M16":
                    spezDurchmesser = 16;
                    spezSteigung = 2;
                    break;
                case "M20":
                    spezDurchmesser = 20;
                    spezSteigung = 2.5;
                    break;
                case "M24":
                    spezDurchmesser = 24;
                    spezSteigung = 3;
                    break;
                case "M30":
                    spezDurchmesser = 30;
                    spezSteigung = 3.5;
                    break;
                case "M36":
                    spezDurchmesser = 36;
                    spezSteigung = 4;
                    break;
                case "M42":
                    spezDurchmesser = 42;
                    spezSteigung = 4.5;
                    break;
                


                default: // Falls ein nicht aufgelistetes Gewinde benutzt wird wird default ausgegeben
                    Console.WriteLine("Gewinde leider nicht vorhanden, prüfen Sie Ihre Rechtschreibung: " + Gewinde + " Ist die Rechtschreibung korrekt, prüfen Sie, ob es sich bei Ihrem Wunsch um ein metrisches Regelgewinde handelt.");
                    break;

            }
            switch (Gewinde_Fein)
            {
                case "M2x0,25":
                    spezDurchmesser = 2;
                    spezSteigung = 0.25;
                    break;              
                case "M3x0,25":
                    spezDurchmesser = 3;
                    spezSteigung = 0.25;
                    break;
                case "M4x0,2":
                    spezDurchmesser = 4;
                    spezSteigung = 0.2;
                    break;
                case "M4x0,35":
                    spezDurchmesser = 4;
                    spezSteigung = 0.35;
                    break;
                case "M5x0,25":
                    spezDurchmesser = 5;
                    spezSteigung = 0.25;
                    break;
                case "M5x0,5":
                    spezDurchmesser = 5;
                    spezSteigung = 0.5;
                    break;
                case "M6x0,25":
                    spezDurchmesser = 6;
                    spezSteigung = 0.25;
                    break;
                case "M6x0,5":
                    spezDurchmesser = 6;
                    spezSteigung = 0.5;
                    break;
                case "M6x0,75":
                    spezDurchmesser = 6;
                    spezSteigung = 0.75;
                    break;
                case "M8x0,25":
                    spezDurchmesser = 8;
                    spezSteigung = 0.25;
                    break;
                case "M8x0,5":
                    spezDurchmesser = 8;
                    spezSteigung = 0.5;
                    break;
                case "M8x1":
                    spezDurchmesser = 8;
                    spezSteigung = 1;
                    break;
                case "M10x0,25":
                    spezDurchmesser = 10;
                    spezSteigung = 0.25;
                    break;
                case "M10x0,5":
                    spezDurchmesser = 10;
                    spezSteigung = 0.5;
                    break;
                case "M10x1":
                    spezDurchmesser = 10;
                    spezSteigung = 1;
                    break;
                case "M12x0,35":
                    spezDurchmesser = 12;
                    spezSteigung = 0.35;
                    break;
                case "M12x0,5":
                    spezDurchmesser = 12;
                    spezSteigung = 0.5;
                    break;
                case "M12x1":
                    spezDurchmesser = 12;
                    spezSteigung = 1;
                    break;
                case "M16x0,5":
                    spezDurchmesser = 16;
                    spezSteigung = 0.5;
                    break;
                case "M16x1":
                    spezDurchmesser = 16;
                    spezSteigung = 1;
                    break;
                case "M16x1,5":
                    spezDurchmesser = 16;
                    spezSteigung = 1.5;
                    break;
                case "M20x1":
                    spezDurchmesser = 20;
                    spezSteigung = 1;
                    break;
                case "M20x1,5":
                    spezDurchmesser = 20;
                    spezSteigung = 1.5;
                    break;
                case "M24x1,5":
                    spezDurchmesser = 24;
                    spezSteigung = 1.5;
                    break;
                case "M24x2":
                    spezDurchmesser = 24;
                    spezSteigung = 2;
                    break;
                case "M30x1,5":
                    spezDurchmesser = 30;
                    spezSteigung = 1.5;
                    break;
                case "M30x2":
                    spezDurchmesser = 30;
                    spezSteigung = 2;
                    break;
                case "M36x1,5":
                    spezDurchmesser = 36;
                    spezSteigung = 1.5;
                    break;
                case "M36x2":
                    spezDurchmesser = 36;
                    spezSteigung = 2;
                    break;
                case "M42x1,5":
                    spezDurchmesser = 42;
                    spezSteigung = 1.5;
                    break;
                case "M42x2":
                    spezDurchmesser = 42;
                    spezSteigung = 2;
                    break;



                default: // Falls ein nicht aufgelistetes Gewinde benutzt wird wird default ausgegeben
                    Console.WriteLine("Gewinde leider nicht vorhanden, prüfen Sie Ihre Rechtschreibung: " + Gewinde_Fein + " Ist die Rechtschreibung korrekt, prüfen Sie, ob es sich bei Ihrem Wunsch um ein metrisches Feingewinde handelt.");
                    break;

            }

            spezFlankendurchmesser = (spezDurchmesser - 0.6495 * spezSteigung);
            spezKerndurchmesser = (spezDurchmesser - 1.2269 * spezSteigung);
            spezKernlochdurchmesser = (spezDurchmesser - spezSteigung);


            return (_durchmesser:spezDurchmesser, _steigung:spezSteigung,_kernloch:spezKernlochdurchmesser, _kern:spezKerndurchmesser, _flanken:spezFlankendurchmesser ); 

        }









    }

}
