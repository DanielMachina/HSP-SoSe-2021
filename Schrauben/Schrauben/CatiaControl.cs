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
                    cc.ErzeugeSechsKopfSkizze(ExcelControl.SWM);
                    Console.WriteLine("4");

                    // Extrudiere Volumen SechsKopf
                    cc.ErzeugeSechskopf(ExcelControl.Kopfhöhe);
                    Console.WriteLine("5");

                    // create cylinder head sketch
                    //cc.ZylinderkopfSkizze(ExcelControl.Zyldurch);
                    Console.WriteLine("6");

                    // create cylinder head pad
                    //cc.ZylinderInnensechkantSkizze(10);
                    Console.WriteLine("7");

                    //create hex socket
                    Console.WriteLine("8");
                    //cc.Zylinderkopf(ExcelControl.Kopfhöhe);

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
