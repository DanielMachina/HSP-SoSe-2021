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
        public static double Durchmesser { get; set; }
        public static double Steigung { get; set; }
        public static double Flankendurchmesser { get; set; }
        public static double Kerndurchmesser { get; set; }
        public static double Kernlochdurchmesser { get; set; }
        public static double Gesamtmasse { get; set; }
        public static double SW { get; set; }
        public static string Re { get; set; }
        public static string Rm { get; set; }
        public static double Preis { get; set; }
        public static double FTM { get; set; }



            Excel.Application excelApp = new Excel.Application();
        public ExcelControl()
        {

            // Objekt erzeugen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Erzeuge Excel COM Objekt");
            Console.ResetColor();
            Console.WriteLine("");
            excelApp.Visible = false;

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

            Excel._Worksheet mySheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Schreiben in die Datei
            //Hier kommen die eingaben der WPF an. Egal was wird weitergegeben und in Excel sortiert und berechnet.
            //XlSchreiben(mySheet);
            string Gewinde = GUI.durchmesser;
            string Laenge = GUI.schraubenlänge;
            string Kopf = GUI.kopfform;
            string Material = GUI.material;
            string Menge = GUI.menge;
            string Festigkeit = GUI.festigkeit;


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Schreibe in die Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            mySheet.Cells[8, "B"] = Material;
            mySheet.Cells[9, "B"] = Laenge;
            mySheet.Cells[11, "B"] = Kopf;
            mySheet.Cells[13, "B"] = Gewinde;
            mySheet.Cells[14, "B"] = Menge;
            mySheet.Cells[16, "B"] = Festigkeit;



            // Lesen der Datei
            //XlLesen(mySheet);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lese aus der Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            Excel.Range bereich = mySheet.Cells[50, "C"] as Excel.Range;
            Durchmesser = (Double)bereich.Value;
            Console.WriteLine("   Durchmesser: " + Durchmesser);

            bereich = mySheet.Cells[51, "C"] as Excel.Range;
            Steigung = (Double)bereich.Value;
            Console.WriteLine("   Steigung: " + Steigung);

            bereich = mySheet.Cells[52, "C"] as Excel.Range;
            Flankendurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Flankendurchmesser: " + Flankendurchmesser);

            bereich = mySheet.Cells[53, "C"] as Excel.Range;
            Kerndurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Kerndurchmesser: " + Kerndurchmesser);

            bereich = mySheet.Cells[54, "C"] as Excel.Range;
            Kernlochdurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Kernlochdurchmesser: " + Kernlochdurchmesser);

            bereich = mySheet.Cells[55, "C"] as Excel.Range;
            Gesamtmasse = (Double)bereich.Value;
            Console.WriteLine("   Gesamtmasse: " + Gesamtmasse);

            bereich = mySheet.Cells[56, "C"] as Excel.Range;
            SW = (Double)bereich.Value;
            Console.WriteLine("   SW: " + SW);

            bereich = mySheet.Cells[57, "C"] as Excel.Range;
            Re = (String)bereich.Value;
            Console.WriteLine("   Re: " + Re);

            bereich = mySheet.Cells[58, "C"] as Excel.Range;
            Rm = (String)bereich.Value;
            Console.WriteLine("   Rm: " + Rm);

            bereich = mySheet.Cells[59, "C"] as Excel.Range;
            Preis = (Double)bereich.Value;
            Console.WriteLine("   Preis: " + Preis);

            bereich = mySheet.Cells[60, "C"] as Excel.Range;
            FTM = (Double)bereich.Value;
            Console.WriteLine("   FTM: " + FTM);
            Console.WriteLine("");


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

/*
        public void XlSchreiben(Excel._Worksheet mySheet)
        {

            string Gewinde = GUI.durchmesser;
            string Laenge = GUI.schraubenlänge;
            string Kopf = GUI.kopfform;
            string Material = GUI.material;
            string Menge = GUI.menge;
            string Festigkeit = GUI.festigkeit;


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Schreibe in die Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            mySheet.Cells[8, "B"] = Material;
            mySheet.Cells[9, "B"] = Laenge;
            mySheet.Cells[11, "B"] = Kopf;
            mySheet.Cells[13, "B"] = Gewinde;
            mySheet.Cells[14, "B"] = Menge;
            mySheet.Cells[16, "B"] = Festigkeit;


        }


        public void XlLesen(Excel._Worksheet mySheet)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lese aus der Excel-Datei");
            Console.ResetColor();
            Console.WriteLine("");
            Excel.Range bereich = mySheet.Cells[50, "C"] as Excel.Range;
            Durchmesser = (Double)bereich.Value;
            Console.WriteLine("   Durchmesser: " + Durchmesser);

            bereich = mySheet.Cells[51, "C"] as Excel.Range;
            Steigung = (Double)bereich.Value;
            Console.WriteLine("   Steigung: " + Steigung);

            bereich = mySheet.Cells[52, "C"] as Excel.Range;
            Flankendurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Flankendurchmesser: " + Flankendurchmesser);

            bereich = mySheet.Cells[53, "C"] as Excel.Range;
            Kerndurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Kerndurchmesser: " + Kerndurchmesser);

            bereich = mySheet.Cells[54, "C"] as Excel.Range;
            Kernlochdurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Kernlochdurchmesser: " + Kernlochdurchmesser);

            bereich = mySheet.Cells[55, "C"] as Excel.Range;
            Gesamtmasse = (Double)bereich.Value;
            Console.WriteLine("   Gesamtmasse: " + Gesamtmasse);

            bereich = mySheet.Cells[56, "C"] as Excel.Range;
            SW = (Double)bereich.Value;
            Console.WriteLine("   SW: " + SW);

            bereich = mySheet.Cells[57, "C"] as Excel.Range;
            Re = (String)bereich.Value;
            Console.WriteLine("   Re: " + Re);

            bereich = mySheet.Cells[58, "C"] as Excel.Range;
            Rm = (String)bereich.Value;
            Console.WriteLine("   Rm: " + Rm);

            bereich = mySheet.Cells[59, "C"] as Excel.Range;
            Preis = (Double)bereich.Value;
            Console.WriteLine("   Preis: " + Preis);

            bereich = mySheet.Cells[60, "C"] as Excel.Range;
            FTM = (Double)bereich.Value;
            Console.WriteLine("   FTM: " + FTM);
            Console.WriteLine("");
             
        }
*/



    }
}

