using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Schrauben
{
    class Class1
    {
        public static void Datensammlung()
        {
            object[,,] Schraube = new object[10, 4, 4];
            Schraube[0, 0, 0] = "Metrisch";
            Schraube[0, 0, 1] = "Zöllisch";
            Schraube[0, 0, 2] = "Holz";
            Schraube[0, 0, 3] = "Metrisch Fein";
            Schraube[0, 1, 0] = "M8";
            Schraube[0, 2, 0] = "M10";
            Schraube[0, 3, 0] = "M12";
            Schraube[0, 1, 1] = "1Zoll";
            Schraube[0, 2, 1] = "2Zoll";
            Schraube[0, 3, 1] = "3Zoll";
            Schraube[1, 1, 0] = "Metrischer M8 Kern1";
            Schraube[2, 1, 0] = "Metrischer M8 Kern2";
            Schraube[1, 2, 0] = "Metrischer M10 Kern1";
            Schraube[2, 2, 0] = "Metrischer M10 Kern2";
            Schraube[1, 2, 1] = "Zölliger 2Zoll Kern1";
            Schraube[2, 2, 1] = "Zölliger 2Zoll Kern2";



            Console.WriteLine(Schraube[0, 0, 0]);
            Console.WriteLine(Schraube[0, 1, 0]);
            Console.WriteLine(Schraube[1,1,0]);
            

            Console.ReadKey();

        }

    }
}
