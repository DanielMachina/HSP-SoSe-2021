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
            Console.WriteLine("Bitte gewünschtes Material eingeben. Es stehen Stahl, Aluminium, Messing, Kupfer und Titan zur Verfügung.");
            eins.Material = Convert.ToString(Console.ReadLine());
            //Ausgabe Material
            Console.WriteLine($"Die Dichte ist {eins.getDichte(eins.Material)}");

            //Eingabe Durchmesser
            Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von M1 bis M42 Schrauben zur Auswahl.");
            eins.Gewinde = Convert.ToString(Console.ReadLine());
            //Ausgabe Durchmesser und Steigung
            eins.Ausgabe(eins);

            Console.ReadKey();

        }
    }

    public class Schraubendefinition //hier wird die Schraube definiert
    {
        public string Material //Eigenschaft Material. Wird in main definiert
        { get; set; }
        public string Gewinde //Eigenschaft Gewinde. Wird in main definiert
        { get; set; }

        public void Ausgabe(Schraubendefinition eins)
        {
            var zahlen = eins.getDurchmesser(eins.Gewinde);
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



        public (double _durchmesser, double _steigung, double _kernloch, double _kern, double _flanken) getDurchmesser(string durchmesser) // Methode um den Durchmesser der jeweiligen M-Größe zu bekommen
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
                case "4":
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

            spezFlankendurchmesser = (spezDurchmesser - 0.6495 * spezSteigung);
            spezKerndurchmesser = (spezDurchmesser - 1.2269 * spezSteigung);
            spezKernlochdurchmesser = (spezDurchmesser - spezSteigung);


            return (_durchmesser:spezDurchmesser, _steigung:spezSteigung,_kernloch:spezKernlochdurchmesser, _kern:spezKerndurchmesser, _flanken:spezFlankendurchmesser ); 

        }









    }

}
