using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Schrauben
{
    class Ausdrucken // : ExcelControl
    {
        _Excel.Application excelApp = new _Excel.Application();
        _Excel._Worksheet mySheet;
        _Excel.Range Xrange;
        _Excel.Borders myBorders;

        internal Ausdrucken()
        {
            // Tool Eingaben
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;
            excelApp.Workbooks.Add();

            mySheet = (_Excel.Worksheet)excelApp.ActiveSheet;

            //Name Ein- Ausgabewerte
            mySheet.Cells[2, "a"] = "Produktdatenblatt";

            mySheet.Cells[5, "a"] = "Firma";
            mySheet.Cells[7, "a"] = "Adresse";
            mySheet.Cells[9, "a"] = "Plz / Ort";
            mySheet.Cells[11, "a"] = "Tel.";

            //Eingabe
            mySheet.Cells[14, "a"] = "Schraubenkonfiguration";
            mySheet.Cells[15, "a"] = "Material: ";
            mySheet.Cells[16, "a"] = "Schraubenart: ";
            mySheet.Cells[17, "a"] = "Nennmaß: ";
            mySheet.Cells[18, "a"] = "Festigkeitsklasse: ";
            mySheet.Cells[19, "a"] = "Schraubenlänge: ";
            mySheet.Cells[20, "a"] = "Gewindelänge: ";
            mySheet.Cells[21, "a"] = "Kopfform: ";
            mySheet.Cells[22, "a"] = "Drehsinn: ";
            mySheet.Cells[23, "a"] = "Menge: ";

            //Ausgabe
            mySheet.Cells[28, "a"] = "Schlüsselweite: ";
            mySheet.Cells[29, "a"] = "Durchmesser: ";
            mySheet.Cells[30, "a"] = "Steigung: ";
            mySheet.Cells[31, "a"] = "Flankendurchmesser: ";
            mySheet.Cells[32, "a"] = "Kerndurchmesser: ";
            mySheet.Cells[33, "a"] = "Kernlochdurchmesser: ";
            mySheet.Cells[34, "a"] = "Streckgrenze: ";
            mySheet.Cells[35, "a"] = "Zugfestigkeit: ";
            mySheet.Cells[36, "a"] = "Flächenträgheitsmoment: ";
            mySheet.Cells[37, "a"] = "Gesamtmasse";

            mySheet.Cells[39, "a"] = "Preis";


            //Eingaben zentrieren
            mySheet.Range["A5", "A11"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet.Range["A15", "A23"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet.Range["A28", "A39"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;

            mySheet.Range["b15", "b23"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet.Range["b28", "b39"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;

            mySheet.Range["c15", "c23"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet.Range["c28", "c39"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;

            //Schriftgröße
            mySheet.Range["A5", "A11"].Font.Size = 9;

            mySheet.Range["A15", "A23"].Font.Size = 11;
            mySheet.Range["b15", "b23"].Font.Size = 11;
            mySheet.Range["c15", "c23"].Font.Size = 11;

            mySheet.Range["A28", "A39"].Font.Size = 11;
            mySheet.Range["b28", "b39"].Font.Size = 11;
            mySheet.Range["c28", "c39"].Font.Size = 11;

            //fett
            mySheet.Range["A2"].Font.Bold = true;
            mySheet.Range["A14"].Font.Bold = true;


            //Schriftgröße nochmal anpassen
            mySheet.Range["A2"].Font.Size = 24;
            mySheet.Range["A14"].Font.Size = 16;
            mySheet.Range["a39"].Font.Size = 16;
            mySheet.Range["b39"].Font.Size = 16;
            mySheet.Range["c39"].Font.Size = 16;

            //Zellen zsm Überschrft und zentrieren
            mySheet.Range["a2:D2"].Merge();
            mySheet.Range["a14:c14"].Merge();
            mySheet.Range["a42:b42"].Merge();

            mySheet.Range["A2", "D2"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet.Range["A14", "c14"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet.Range["A42", "b42"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet.Range["f4", "f7"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;

            mySheet.Range["a2:D2"].Font.Underline = _Excel.XlUnderlineStyle.xlUnderlineStyleSingle;

            //Datum
            mySheet.Cells[7, "f"] = DateTime.Today;


            //Rahmen Eingabe
            Xrange = mySheet.get_Range("A15:c23");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;

            //Rahmen Ausgabe
            Xrange = mySheet.get_Range("A26:c37");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;

            //Rahmen Preis
            Xrange = mySheet.get_Range("A39:c39");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;

            //Rahmen üKontakt
            Xrange = mySheet.get_Range("e3:f3");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;

            //Rahmen üDatum
            Xrange = mySheet.get_Range("e6:f6");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;

            //Rahmen uDatum
            Xrange = mySheet.get_Range("e7:f7");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;

            //Rahmen üFirma
            Xrange = mySheet.get_Range("a4:c4");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;


            //autofit
            mySheet.Range["A1", "g48"].EntireColumn.AutoFit();



            //Daten in Felder ausgeben
            mySheet.Cells[15, "C"] = ExcelControl.Material;
            //mySheet.Cells[16, "C"] = GUI.Schraubenart;
            mySheet.Cells[17, "C"] = ExcelControl.Gewinde;
            mySheet.Cells[18, "C"] = ExcelControl.Festigkeit;
            mySheet.Cells[19, "C"] = ExcelControl.Laenge;
            //mySheet.Cells[20, "C"] = GUI.Gewindlaenge;
            mySheet.Cells[21, "C"] = ExcelControl.Kopf;
            //mySheet.Cells[22, "C"] = GUI.Drehsinn;
            mySheet.Cells[23, "C"] = ExcelControl.Menge;


            //mySheet.Cells[28, "C"] = GUI.SW aus Textbox;
            mySheet.Cells[29, "C"] = ExcelControl.Durchmesser;
            mySheet.Cells[30, "C"] = ExcelControl.Steigung;
            mySheet.Cells[31, "C"] = ExcelControl.Flankendurchmesser;
            mySheet.Cells[32, "C"] = ExcelControl.Kerndurchmesser;
            mySheet.Cells[33, "C"] = ExcelControl.Kernlochdurchmesser;
            mySheet.Cells[34, "C"] = ExcelControl.Re;
            mySheet.Cells[35, "C"] = ExcelControl.Rm;
            mySheet.Cells[36, "C"] = ExcelControl.FTM;
            mySheet.Cells[37, "C"] = ExcelControl.Gesamtmasse;



            // als PDF speichern
            /*mySheet.ExportAsFixedFormat(_Excel.XlFixedFormatType.xlTypePDF,
                                       //"e\\Schraube Ausgabe Produktdatenblatt" 
                                       ExcelControl.Material + ExcelControl.Gewinde + ExcelControl.Laenge +
                                       ExcelControl.Menge, _Excel.XlFixedFormatQuality.xlQualityStandard,
                                       true, true, 1, 1, true);
            */
            //String filename = "Produktdatenblatt.pdf";
            String filename = System.IO.Path.Combine("Produktdatenblatt" + ExcelControl.Material + ExcelControl.Gewinde + ExcelControl.Laenge +
                                       ExcelControl.Menge + ".pdf");
            String path = System.IO.Path.GetFullPath(filename);


            mySheet.SaveAs(filename);
            //excelApp.Quit();




        }
    }


}
