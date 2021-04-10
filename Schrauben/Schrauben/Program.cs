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
            //Material wird definiert
            Console.WriteLine("Bitte gewünschtes Material eingeben. Es stehen Stahl, Aluminium und Titan zur Verfügung.");
            
            eins.Material = Console.ReadLine(); //Material selber eingebbar.

            //Ausgabe
            Console.WriteLine(eins.getDichte(eins.Material));


            Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von M1 bis M42 Schrauben zur Auswahl.");
            eins.Gewinde = Console.ReadLine(); //Gewinde eingeben, da ja noch keine Auswahlfenster zur Verfügung stehen
            Console.WriteLine(eins.getDurchmesser(eins.Gewinde));
            Console.ReadKey();


        }
       


    }

    public class Schraubendefinition //hier wird die Schraube definiert
    {
        public string Material //Eigenschaft Material. Wird in main definiert
        { get; set; }

        public double getDichte(string material) // Methode um Dichte des jeweiligen Materials zu bekommen
        {
            double spezDichte = 0;

                switch (Material)
                {
                    case "Stahl": //Jeder case kann ein Material annehmen
                        Console.WriteLine("Das Material ist " + Material);
                        spezDichte = 7.85; // Hier bekommt  das Material seine Dichte
                        break;
                    case "Aluminium":
                        Console.WriteLine("Das Material ist " + Material);
                        spezDichte = 2.7;
                        break;
                    case "Titan":
                        Console.WriteLine("Das Material ist " + Material);
                        spezDichte = 4.507;
                        break;
                    //Hier können mehr Materialien rein

                    default: // Falls ein nicht aufgelistetes Material benutzt wird wird default ausgegeben
                        Console.WriteLine("Material leider nicht vorhanden, prüfe deine Rechtschreibung: " + Material);

                        break;
                }

                Console.Write("Die Dichte ist ");
                return spezDichte;
        }

        
        //Wilde Experimente, indem ich den Code vom Material kopiere und dann versuche in z.B. Gewinde aussuchen per selber codieren zuu ändern.



        public string Gewinde //Eigenschaft Gewinde. Wird in main definiert
        { get; set; }

        public double getDurchmesser(string durchmesser) // Methode um den Durchmesser der jeweiligen M-Größe zu bekommen
        {
            double spezDurchmesser = 0;
            switch (Gewinde)
            {
                case "M1": //Jeder case kann eine Größe annehmen
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 1; // Hier bekommt  das Gewinde seinen Durchmesser
                    break;
                case "M1,2":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 1.2;
                    break;
                case "M1,6":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 1.6;
                    break;
                case "M2":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 2;
                    break;
                case "M2,5":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 2.5;
                    break;
                case "M3":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 3;
                    break;
                case "4":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 4;
                    break;
                case "M5":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 5;
                    break;
                case "M6":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 6;
                    break;
                case "M8":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 8;
                    break;
                case "M10":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 10;
                    break;
                case "M12":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 12;
                    break;
                case "M16":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 16;
                    break;
                case "M20":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 20;
                    break;
                case "M24":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 24;
                    break;
                case "M30":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 30;
                    break;
                case "M36":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 36;
                    break;
                case "M42":
                    Console.WriteLine("Die Regelgewinde-Bezeichnung ist " + Gewinde);
                    spezDurchmesser = 42;
                    break;
                

                //Hier können mehr Gewinde rein, falls nötig

                default: // Falls ein nicht aufgelistetes Gewinde benutzt wird wird default ausgegeben
                    Console.WriteLine("Gewinde leider nicht vorhanden, prüfen Sie Ihre Rechtschreibung: " + Gewinde + " Ist die Rechtschreibung korrekt, prüfen Sie, ob es sich bei Ihrem Wunsch um ein metrisches Regelgewinde handelt.");
                    break;

            }

            Console.Write("Der Gewinde-Nenndurchmesser beträgt ");
            return spezDurchmesser;

        }









    }

}
