using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{
    public class CatiaControl
    {
        public CatiaControl()
        {
            try
            {

                CatiaConnection cc = new CatiaConnection();

                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {
                    Console.WriteLine("0");

                    // Öffne ein neues Part
                    cc.ErzeugePart();
                    Console.WriteLine("1");

                    // Erstelle eine leere Skizze
                    cc.ErstelleLeereSkizze();
                    Console.WriteLine("2");

                    Schraube dieSchraube = new Schraube(Convert.ToDouble(GUI.schraubenlänge), Convert.ToDouble(GUI.gewindelänge), GUI.schraubenart, GUI.durchmesser, 5.3d, ExcelControl.Durchmesser / 2, ExcelControl.Steigung);

                    cc.ErzeugeZylinder(dieSchraube);
                    Console.WriteLine("Schaft");

                    //Erstelle Gewinde optisch oder als technisch (muss über Radio-Button noch eingefügt werden).
                    /*if (Darstellung == "optisch")
                    {
                        cc.ErzeugeGewindeHelix(dieSchraube);
                    }
                    else
                    {
                        cc.ErzeugeGewindeFeature();
                    }
                    */

                    cc.ErzeugeGewindeHelix(dieSchraube);
                    Console.WriteLine("Gewinde");

                    // Generiere einen Offset
                    cc.ErzeugeOffset(Convert.ToDouble(ExcelControl.Laenge));
                    Console.WriteLine("3");

                    // Generiere einen Kopf
                    //cc.ErzeugeSechsKopfSkizze(20, ExcelControl.SWM);
                    Console.WriteLine("3");

                    // Extrudiere Volumen Kopf
                    //cc.ErzeugeSechskopf(15);
                    Console.WriteLine("4");


                }
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }


            Console.WriteLine("Fertig - Taste drücken.");
            //Console.ReadKey();

        }

    }
}
