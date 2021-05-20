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
        _Excel._Worksheet mySheet2;
        _Excel.Range Xrange;
        _Excel.Borders myBorders;

        internal Ausdrucken()
        {
            // Tool Eingaben
            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
            excelApp.Workbooks.Add();

            mySheet2 = (_Excel.Worksheet)excelApp.ActiveSheet;

            //Name Ein- Ausgabewerte
            mySheet2.Cells[2, "a"] = "Produktdatenblatt";

            mySheet2.Cells[5, "a"] = "Firma";
            mySheet2.Cells[4, "a"] = "Schraubentechnik GmbH & Co. KG";

            mySheet2.Cells[7, "a"] = "Adresse";
            mySheet2.Cells[6, "a"] = "Musterweg 1";

            mySheet2.Cells[9, "a"] = "Plz / Ort";
            mySheet2.Cells[8, "a"] = "26386 Wilhelmshaven";

            mySheet2.Cells[11, "a"] = "Tel.";
            mySheet2.Cells[10, "a"] = "01234/0123456789";

            //Eingabe
            mySheet2.Cells[14, "a"] = "Schraubenkonfiguration";

            mySheet2.Cells[16, "a"] = "Ihre Eingaben:";
            mySheet2.Cells[17, "a"] = "Material: ";
            mySheet2.Cells[18, "a"] = "Schraubenart: ";
            mySheet2.Cells[19, "a"] = "Nennmaß: ";
            mySheet2.Cells[20, "a"] = "Festigkeitsklasse: ";
            mySheet2.Cells[21, "a"] = "Schraubenlänge: ";
            mySheet2.Cells[22, "a"] = "Gewindelänge: ";
            mySheet2.Cells[23, "a"] = "Kopfform: ";
            mySheet2.Cells[24, "a"] = "Drehsinn: ";
            mySheet2.Cells[25, "a"] = "Menge: ";

            //Ausgabe
            mySheet2.Cells[27, "a"] = "Schraubenwerte:";
            mySheet2.Cells[28, "a"] = "Schlüsselweite: ";
            mySheet2.Cells[29, "a"] = "Durchmesser: ";
            mySheet2.Cells[30, "a"] = "Steigung: ";
            mySheet2.Cells[31, "a"] = "Flankendurchmesser: ";
            mySheet2.Cells[32, "a"] = "Kerndurchmesser: ";
            mySheet2.Cells[33, "a"] = "Kernlochdurchmesser: ";
            mySheet2.Cells[34, "a"] = "Streckgrenze: ";
            mySheet2.Cells[35, "a"] = "Zugfestigkeit: ";
            mySheet2.Cells[36, "a"] = "Flächenträgheitsmoment: ";
            mySheet2.Cells[37, "a"] = "Gesamtmasse";

            mySheet2.Cells[39, "a"] = "Preis";


            //Eingaben zentrieren
            mySheet2.Range["A4", "B11"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet2.Range["A16", "A25"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet2.Range["A27", "A39"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;

            mySheet2.Range["b16", "b25"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet2.Range["b27", "b39"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;

            mySheet2.Range["c16", "c25"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;
            mySheet2.Range["c27", "c39"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;

            //Schriftgröße
            mySheet2.Range["A5"].Font.Size = 8;
            mySheet2.Range["A7"].Font.Size = 8;
            mySheet2.Range["A9"].Font.Size = 8;
            mySheet2.Range["A11"].Font.Size = 8;

            mySheet2.Range["A4"].Font.Size = 10;
            mySheet2.Range["A6"].Font.Size = 10;
            mySheet2.Range["A8"].Font.Size = 10;
            mySheet2.Range["A10"].Font.Size = 10;

            mySheet2.Range["A16", "A25"].Font.Size = 11;
            mySheet2.Range["b16", "b25"].Font.Size = 11;
            mySheet2.Range["c16", "c25"].Font.Size = 11;

            mySheet2.Range["A27", "A39"].Font.Size = 11;
            mySheet2.Range["b27", "b39"].Font.Size = 11;
            mySheet2.Range["c27", "c39"].Font.Size = 11;

            //fett
            mySheet2.Range["A2"].Font.Bold = true;
            mySheet2.Range["A14"].Font.Bold = true;


            //Schriftgröße nochmal anpassen
            mySheet2.Range["A2"].Font.Size = 24;
            mySheet2.Range["A14"].Font.Size = 16;
            mySheet2.Range["a39"].Font.Size = 16;
            mySheet2.Range["b39"].Font.Size = 16;
            mySheet2.Range["c39"].Font.Size = 16;

            //Zellen zsm Überschrift und zentrieren
            mySheet2.Range["a2:D2"].Merge();
            mySheet2.Range["a4:c4"].Merge();
            mySheet2.Range["a6:c6"].Merge();
            mySheet2.Range["a8:c8"].Merge();
            mySheet2.Range["a10:c10"].Merge();
            mySheet2.Range["e4:f4"].Merge();
            mySheet2.Range["e5:f6"].Merge();
            mySheet2.Range["a14:c14"].Merge();
            mySheet2.Range["a42:b42"].Merge();
            mySheet2.Range["e2:f3"].Merge();
            mySheet2.Range["a16:c16"].Merge();
            mySheet2.Range["a27:c27"].Merge();

            mySheet2.Range["A2", "D2"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet2.Range["A14", "c14"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet2.Range["A42", "b42"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet2.Range["f4", "f7"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet2.Range["a16", "c16"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;
            mySheet2.Range["a27", "c27"].HorizontalAlignment = _Excel.XlHAlign.xlHAlignCenter;

            mySheet2.Range["a2:D2"].Font.Underline = _Excel.XlUnderlineStyle.xlUnderlineStyleSingle;

            //Datum
            mySheet2.Cells[7, "e"] = "Datum";
            mySheet2.Cells[7, "f"] = DateTime.Today;

            //Kontakt
            mySheet2.Cells[4, "e"] = "Kontakt:";
            mySheet2.Cells[5, "e"] = "Kai Mecke";
            mySheet2.Range["e4", "f5"].EntireColumn.HorizontalAlignment = _Excel.XlHAlign.xlHAlignLeft;


            //Rahmen Eingabe
            Xrange = mySheet2.get_Range("A16:c25");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;

            //Rahmen Ausgabe
            Xrange = mySheet2.get_Range("A27:c37");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;

            //Rahmen Preis
            Xrange = mySheet2.get_Range("A39:c39");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;

            //Rahmen üKontakt Datum Bild
            Xrange = mySheet2.get_Range("E2:F7");
            myBorders = Xrange.Borders;
            myBorders.Weight = _Excel.XlBorderWeight.xlThick;
            myBorders.Weight = 2d;
            

            //Rahmen üFirma
            Xrange = mySheet2.get_Range("a4:c4");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;

            //Rahmen Add
            Xrange = mySheet2.get_Range("a6:c6");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;

            //Rahmen PLZ
            Xrange = mySheet2.get_Range("a8:c8");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;

            //Rahmen Tel
            Xrange = mySheet2.get_Range("a10:c10");
            myBorders = Xrange.Borders;
            myBorders[_Excel.XlBordersIndex.xlEdgeBottom].Color = ConsoleColor.Black;


            //autofit
            mySheet2.Range["a1", "g45"].EntireColumn.AutoFit();
            /*
            mySheet2.Range["a1", "d16"].EntireColumn.AutoFit();
            mySheet2.Range["a17", "a38"].EntireColumn.AutoFit();
            mySheet2.Range["a39", "c39"].EntireColumn.AutoFit();
            mySheet2.Range["c17", "c37"].EntireColumn.AutoFit();
            mySheet2.Range["e1", "f6"].EntireColumn.AutoFit();
            mySheet2.Range["b17", "b37"].EntireColumn.ColumnWidth(50);
            */


            //Daten in Felder ausgeben
            mySheet2.Cells[17, "B"] = ExcelControl.Material;
            mySheet2.Cells[18, "B"] = GUI.schraubenart;
            mySheet2.Cells[19, "B"] = ExcelControl.Gewinde;
            mySheet2.Cells[20, "B"] = ExcelControl.Festigkeit;
            mySheet2.Cells[21, "B"] = ExcelControl.Laenge;
            mySheet2.Cells[21,"C"] = "mm";
            mySheet2.Cells[22, "B"] = GUI.gewindelänge;
            mySheet2.Cells[21, "C"] = "mm";
            mySheet2.Cells[23, "B"] = ExcelControl.Kopf;
            mySheet2.Cells[24, "B"] = GUI.Drehsinn;
            mySheet2.Cells[25, "B"] = ExcelControl.Menge;
            mySheet2.Cells[25, "C"] = "Stk.";


            mySheet2.Cells[28, "B"] = GUI.SW;
            mySheet2.Cells[29, "B"] = ExcelControl.Durchmesser;
            mySheet2.Cells[29, "C"] = "mm";
            mySheet2.Cells[30, "B"] = ExcelControl.Steigung;
            mySheet2.Cells[30,"C"] = "mm";
            mySheet2.Cells[31, "B"] = ExcelControl.Flankendurchmesser;
            mySheet2.Cells[31,"C"] = "mm";
            mySheet2.Cells[32, "B"] = ExcelControl.Kerndurchmesser;
            mySheet2.Cells[32,"C"] = "mm";
            mySheet2.Cells[33, "B"] = ExcelControl.Kernlochdurchmesser;
            mySheet2.Cells[33,"C"] = "mm";
            mySheet2.Cells[34, "B"] = ExcelControl.Re;
            mySheet2.Cells[34,"C"] = "N/mm^2";
            mySheet2.Cells[35, "B"] = ExcelControl.Rm;
            mySheet2.Cells[35,"C"] = "N/mm^2";
            mySheet2.Cells[36, "B"] = ExcelControl.FTM;
            mySheet2.Cells[36,"C"] = "mm^4";
            mySheet2.Cells[37, "B"] = ExcelControl.Gesamtmasse;
            mySheet2.Cells[37, "C"] = "kg";


            mySheet2.Cells[39, "B"] = ExcelControl.Preis;
            mySheet2.Cells[39, "C"] = "Euro";



            string file = "e";
            string path = System.IO.Path.GetFullPath(file);


            // als PDF speichern 
            mySheet2.ExportAsFixedFormat(_Excel.XlFixedFormatType.xlTypePDF,
                                        "D:\\Produktblatt",
                                       ExcelControl.Material + ExcelControl.Gewinde + ExcelControl.Laenge +
                                       ExcelControl.Menge, _Excel.XlFixedFormatQuality.xlQualityStandard,
                                       true, true, 1, 1, true);

           // mySheet.SaveAs(System.IO.Path.GetDirectoryName(path));

            //String filename = "Produktdatenblatt.pdf";
            //String filename = System.IO.Path.Combine("Produktdatenblatt" + ExcelControl.Material + ExcelControl.Gewinde + ExcelControl.Laenge +
           //                            ExcelControl.Menge + ".pdf");
           // String path = System.IO.Path.GetFullPath(filename);


            
            //excelApp.Quit();




        }
    }


}
