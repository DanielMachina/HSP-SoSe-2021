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
                    Console.WriteLine("1. Neues Part");

                    // Erstelle eine leere Skizze
                    cc.ErstelleLeereSkizze();
                    Console.WriteLine("2. Leere Skizze");

                    Schraube dieSchraube = new Schraube(Convert.ToDouble(GUI.schraubenlänge), Convert.ToDouble(GUI.gewindelänge)-1, GUI.schraubenart, GUI.durchmesser, 5.3d, ExcelControl.Durchmesser / 2, ExcelControl.Steigung);

                    cc.ErzeugeSchaft(dieSchraube);
                    Console.WriteLine("3. Schaft");

                    //Erstelle Gewinde optisch oder als technisch
                    if (GUI.Darstellung == "optisch")
                    {
                        cc.ErzeugeGewindeHelix(dieSchraube);
                        Console.WriteLine("4. Gewinde");
                    }
                    else
                    {
                        cc.ErzeugeGewindeFeature();
                        Console.WriteLine("4. Gewinde");
                        cc.Fase();
                    }

                    if (GUI.kopfform == "Sechskant")
                    {
                        // Generiere einen Sechskantkopf
                        cc.ErzeugeSechsKopfSkizze(ExcelControl.SWM);

                        // Extrudiere Volumen SechsKopf
                        cc.ErzeugeSechskopf(ExcelControl.Kopfhöhe);
                        Console.WriteLine("5. Sechskant");
                    }
                    else if (GUI.kopfform =="Zylinderkopf")
                    {
                        //Zylinderkopf
                        cc.Zylinderkopf();
                        Console.WriteLine("5. Zylinderkopf");
                    }
                    else if (GUI.kopfform =="Senkkopf")
                    {
                        //Senkkopfschraube
                        cc.Senkkopf();
                        Console.WriteLine("5. Senkkopf");

                    }

                    


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
           
        }

    }
}
