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

                    // Erstelle eine Skizze
                    cc.ErstelleLeereSkizze();
                    Console.WriteLine("2");

                    // Generiere ein Profil
                    // cc.ErzeugeProfil(20, 10);
                    // Console.WriteLine("3");

                    // Extrudiere Balken
                    // cc.ErzeugeBalken(300);
                    // Console.WriteLine("4");

                    Schraube dieSchraube = new Schraube(Convert.ToDouble(GUI.schraubenlänge), Convert.ToDouble(GUI.gewindelänge), GUI.schraubenart, GUI.durchmesser, 5.3d, ExcelControl.Durchmesser / 2, ExcelControl.Steigung);

                    cc.ErzeugeZylinder(dieSchraube);
                    Console.WriteLine("Schaft");

                    // cc.ErzeugeGewindeFeature();
                    cc.ErzeugeGewindeHelix(dieSchraube);
                    Console.WriteLine("Gewinde");
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
