using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{


    public class Tools // zur vereinfacherung
    {

        public void Abfrage(string element, string auswahl) // Abfrage von Element und Auswahl 
        {
            if (auswahl != "")
            {
                Console.WriteLine($"Bitte {element} angeben");
                Console.WriteLine($"Es stehen {auswahl} zur verfügung");
            }
            else
            {
                Console.WriteLine($"Bitte {element} angeben");
            }
        }

        public void Ausgabe_Gewinde(Schraubendefinition eins)
        {
            var zahlen = eins.getDurchmesser();
            if (eins.Durchmesser != 0 && eins.Art == "Zoll")
            {
                Console.WriteLine($"Der Durchmesser ist {zahlen._durchmesser} mm");
                Console.WriteLine("");
            }

            else { Console.WriteLine(""); }
        }


    }

}
