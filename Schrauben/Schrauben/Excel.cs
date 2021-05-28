using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Schrauben
{

    public class ExcelControl
    {
        public static string Kopf { get; set; }
        public static string Menge { get; set; }
        public static string Festigkeit { get; set; }
        public static string Laenge { get; set; }
        public static string Gewinde { get; set; }
        public static string Material { get; set; }
        public static double Durchmesser { get; set; }
        public static double Steigung { get; set; }
        public static double Flankendurchmesser { get; set; }
        public static double Kerndurchmesser { get; set; }
        public static double Kernlochdurchmesser { get; set; }
        public static double Gesamtmasse { get; set; }
        public static double SWM { get; set; }
        public static string SWZ { get; set; }
        public static string Re { get; set; }
        public static string Rm { get; set; }
        public static double Preis { get; set; }
        public static double FTM { get; set; }
        public static double Kopfhöhe { get; set; }
        public static double Zyldurch { get; set; }
        public static double Senkdurch { get; set; }




        Excel.Application excelApp = new Excel.Application();
        Excel._Worksheet mySheet;
        public ExcelControl()
        {

            // Objekt erzeugen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Erzeuge Excel COM Objekt");
            Console.ResetColor();
            Console.WriteLine("");
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;

            // Öffnen einer Excel Datei
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Öffne Datei");
            Console.ResetColor();
            Console.WriteLine("");
            String filename = "Tabelle-Werte.xlsx";
            String path = System.IO.Path.GetFullPath(filename);

            if (System.IO.File.Exists(path))
            {
                excelApp.Workbooks.Open(path);
            }

             mySheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Schreiben in die Datei
            //Hier kommen die eingaben der WPF an. Egal was wird weitergegeben und in Excel sortiert und berechnet.
            //XlSchreiben(mySheet);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Schreibe in die Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            mySheet.Cells[8, "B"] = Material = GUI.material;
            mySheet.Cells[9, "B"] = Laenge = GUI.schraubenlänge;
            mySheet.Cells[11, "B"] = Kopf = GUI.kopfform;
            mySheet.Cells[13, "B"] = Gewinde = GUI.durchmesser;
            mySheet.Cells[14, "B"] = Menge = GUI.menge;
            mySheet.Cells[16, "B"] = Festigkeit = GUI.festigkeit;



            // Lesen der Datei
            //XlLesen();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lese aus der Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            Excel.Range bereich = mySheet.Cells[50, "C"] as Excel.Range;
            Durchmesser = Math.Round((Double)bereich.Value,1);
            Console.WriteLine("   Durchmesser: " + Durchmesser);

            bereich = mySheet.Cells[51, "C"] as Excel.Range;
            Steigung = Math.Round((Double)bereich.Value,2);
            Console.WriteLine("   Steigung: " + Steigung);

            bereich = mySheet.Cells[52, "C"] as Excel.Range;
            Flankendurchmesser = Math.Round((Double)bereich.Value,2);
            Console.WriteLine("   Flankendurchmesser: " + Flankendurchmesser);

            bereich = mySheet.Cells[53, "C"] as Excel.Range;
            Kerndurchmesser = Math.Round((Double)bereich.Value,2);
            Console.WriteLine("   Kerndurchmesser: " + Kerndurchmesser);

            bereich = mySheet.Cells[54, "C"] as Excel.Range;
            Kernlochdurchmesser = Math.Round((Double)bereich.Value,2);
            Console.WriteLine("   Kernlochdurchmesser: " + Kernlochdurchmesser);

            bereich = mySheet.Cells[55, "C"] as Excel.Range;
            Gesamtmasse = Math.Round((Double)bereich.Value, 2) ;
            Console.WriteLine("   Gesamtmasse: " + Gesamtmasse);

            bereich = mySheet.Cells[56, "B"] as Excel.Range;
            SWM = (Double)bereich.Value;
            Console.WriteLine("   SWM: " + SWM);

            bereich = mySheet.Cells[56, "E"] as Excel.Range;
            SWZ = (String)bereich.Value;
            Console.WriteLine("   SWZ: " + SWZ);

            bereich = mySheet.Cells[57, "C"] as Excel.Range;
            Re = (String)bereich.Value;
            Console.WriteLine("   Re: " + Re);

            bereich = mySheet.Cells[58, "C"] as Excel.Range;
            Rm = (String)bereich.Value;
            Console.WriteLine("   Rm: " + Rm);

            bereich = mySheet.Cells[59, "C"] as Excel.Range;
            Preis = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Preis: " + Preis);

            bereich = mySheet.Cells[60, "C"] as Excel.Range;
            FTM = Math.Round((Double)bereich.Value);
            Console.WriteLine("   FTM: " + FTM);
            Console.WriteLine("");

            bereich = mySheet.Cells[61, "C"] as Excel.Range;
            Kopfhöhe = Math.Round((Double)bereich.Value);
            Console.WriteLine("   Kopfhöhe: " + Kopfhöhe);

            bereich = mySheet.Cells[62, "C"] as Excel.Range;
            Zyldurch = Math.Round((Double)bereich.Value);
            Console.WriteLine("   Zyldurch: " + Zyldurch);

            bereich = mySheet.Cells[63, "C"] as Excel.Range;
            Senkdurch = Math.Round((Double)bereich.Value);
            Console.WriteLine("   Senkdurch: " + Senkdurch);


            // Speichern der Datei und beenden.
            int z = 0;
            Random Zahl = new Random();
            for (int f = 0; f < 1; f++)
            {
                z = Zahl.Next(-1000000000, 1000000000);

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Speichern der Änderungen");
            Console.WriteLine("");

            int i = z;
            String newFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), "newTabelle-Werte" + i + ".xlsx");


            mySheet.SaveAs(newFileName);
            excelApp.Quit();

            Console.ResetColor();
            
        }


        /*public void XlSchreiben()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Schreibe in die Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            mySheet.Cells[8, "B"] = Material = GUI.material;
            mySheet.Cells[9, "B"] = Laenge = GUI.schraubenlänge;
            mySheet.Cells[11, "B"] = Kopf = GUI.kopfform;
            mySheet.Cells[13, "B"] = Gewinde = GUI.durchmesser;
            mySheet.Cells[14, "B"] = Menge = GUI.menge;
            mySheet.Cells[16, "B"] = Festigkeit = GUI.festigkeit;


        }


        public void XlLesen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lese aus der Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            Excel.Range bereich = mySheet.Cells[50, "C"] as Excel.Range;
            Durchmesser = Math.Round((Double)bereich.Value, 1);
            Console.WriteLine("   Durchmesser: " + Durchmesser);

            bereich = mySheet.Cells[51, "C"] as Excel.Range;
            Steigung = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Steigung: " + Steigung);

            bereich = mySheet.Cells[52, "C"] as Excel.Range;
            Flankendurchmesser = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Flankendurchmesser: " + Flankendurchmesser);

            bereich = mySheet.Cells[53, "C"] as Excel.Range;
            Kerndurchmesser = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Kerndurchmesser: " + Kerndurchmesser);

            bereich = mySheet.Cells[54, "C"] as Excel.Range;
            Kernlochdurchmesser = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Kernlochdurchmesser: " + Kernlochdurchmesser);

            bereich = mySheet.Cells[55, "C"] as Excel.Range;
            Gesamtmasse = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Gesamtmasse: " + Gesamtmasse);

            bereich = mySheet.Cells[56, "B"] as Excel.Range;
            SWM = (Double)bereich.Value;
            Console.WriteLine("   SWM: " + SWM);

            bereich = mySheet.Cells[56, "E"] as Excel.Range;
            SWZ = (String)bereich.Value;
            Console.WriteLine("   SWZ: " + SWZ);

            bereich = mySheet.Cells[57, "C"] as Excel.Range;
            Re = (String)bereich.Value;
            Console.WriteLine("   Re: " + Re);

            bereich = mySheet.Cells[58, "C"] as Excel.Range;
            Rm = (String)bereich.Value;
            Console.WriteLine("   Rm: " + Rm);

            bereich = mySheet.Cells[59, "C"] as Excel.Range;
            Preis = Math.Round((Double)bereich.Value, 2);
            Console.WriteLine("   Preis: " + Preis);

            bereich = mySheet.Cells[60, "C"] as Excel.Range;
            FTM = Math.Round((Double)bereich.Value);
            Console.WriteLine("   FTM: " + FTM);
            Console.WriteLine("");

        }

        */


    }
}

