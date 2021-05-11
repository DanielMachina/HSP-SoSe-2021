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


        public ExcelControl()
        {
            
            // Objekt erzeugen
            
            Console.WriteLine("Erzeuge Excel COM Objekt");
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Öffnen einer Excel Datei
            Console.WriteLine("Öffne Datei");
            String filename = "Tabelle-Werte.xlsx";
            String path = System.IO.Path.GetFullPath(filename);
            if (System.IO.File.Exists(path))
            {
                excelApp.Workbooks.Open(path);
            }
            Excel._Worksheet mySheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Schreiben in die Datei
            //Hier kommen die eingaben der WPF an. Egal was wird weitergegeben und in Excel sortiert und berechnet.
            string Gewinde = "M5";
            string Laenge = "100";
            string Kopf = "Sechskant";
            string Material = "Stahl";
            string Menge = "33";
            string Festigkeit = "10.9";

            Console.WriteLine("Schreibe in die Datei");
            mySheet.Cells[8, "B"] = Material;
            mySheet.Cells[9, "B"] = Laenge;
            mySheet.Cells[11, "B"] = Kopf;
            mySheet.Cells[13, "B"] = Gewinde;
            mySheet.Cells[14, "B"] = Menge;
            mySheet.Cells[16, "B"] = Festigkeit;

            Console.WriteLine(Durch);
            // Lesen der Datei
            Console.WriteLine("Lese aus der Datei");
            Excel.Range bereich = mySheet.Cells[50, "C"] as Excel.Range;
            Double Durchmesser = (Double)bereich.Value;
            Console.WriteLine("   Durchmesser: " + Durchmesser);

            bereich = mySheet.Cells[51, "C"] as Excel.Range;
            Double Steigung = (Double)bereich.Value;
            Console.WriteLine("   Steigung: " + Steigung);

            bereich = mySheet.Cells[52, "C"] as Excel.Range;
            Double Flankendurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Flankendurchmesser: " + Flankendurchmesser);

            bereich = mySheet.Cells[53, "C"] as Excel.Range;
            Double Kerndurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Kerndurchmesser: " + Kerndurchmesser);

            bereich = mySheet.Cells[54, "C"] as Excel.Range;
            Double Kernlochdurchmesser = (Double)bereich.Value;
            Console.WriteLine("   Kernlochdurchmesser: " + Kernlochdurchmesser);

            bereich = mySheet.Cells[55, "C"] as Excel.Range;
            Double Gesamtmasse = (Double)bereich.Value;
            Console.WriteLine("   Gesamtmasse: " + Gesamtmasse);

            bereich = mySheet.Cells[56, "C"] as Excel.Range;
            Double SW = (Double)bereich.Value;
            Console.WriteLine("   SW: " + SW);

            bereich = mySheet.Cells[57, "C"] as Excel.Range;
            String Re = (String)bereich.Value;
            Console.WriteLine("   Re: " + Re);

            bereich = mySheet.Cells[58, "C"] as Excel.Range;
            String Rm = (String)bereich.Value;
            Console.WriteLine("   Rm: " + Rm);

            bereich = mySheet.Cells[59, "C"] as Excel.Range;
            Double Preis = (Double)bereich.Value;
            Console.WriteLine("   Preis: " + Preis);

            bereich = mySheet.Cells[60, "C"] as Excel.Range;
            Double FTM = (Double)bereich.Value;
            Console.WriteLine("   FTM: " + FTM);


            // Speichern der Datei und beenden.
            int z = 0;
            Random Zahl = new Random();
            for (int f = 0; f < 1; f++)
            {
                z = Zahl.Next(-1000000000, 1000000000);
                Console.WriteLine(z);
            }

            Console.WriteLine("Speichern der Änderungen");
            int i = z;
            String newFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), "newTabelle-Werte" + i + ".xlsx");
            mySheet.SaveAs(newFileName);
            excelApp.Quit();


            Console.ReadKey();

        }


        
    }
}

