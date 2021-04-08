using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{
    class Program
    {
        static void Main(string[] args)
        {          
            Schraubendefinition eins = new Schraubendefinition();
            //Material wird definiert
            eins.Material = "Stahl";

            //Asugabe
            Console.WriteLine(eins.getDichte(eins.Material));
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

            Console.Write("Die Dichte ist " );
            return spezDichte;

        }

    }

}
