using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{
    class Program
    {

        public static void Main()
        {


            Schraubendefinition eins = new Schraubendefinition();
            //Eingabe Material
            do
            {
                eins.MaterialAbfrage();
            }
            while (eins.beenden != true);


            //Eingabe Schraubenart
            Console.WriteLine("Bitte geben Sie Ihren gewünschten Schraubenart an. Es gibt Metrisch, Metrisch Fein, Zoll, Trapez -gewinde zur Auswahl.");
            eins.Art = Convert.ToString(Console.ReadLine());
            //Ausgabe Durchmesser und Steigung
            eins.Ausgabe_Gewinde(eins);

            //Eingabe Schraubenkopf
            Console.WriteLine("Bitte gewünschte Schraubenkopf eingeben. Es stehen Sechskant, Zylindrisch und Senkkopf zur Verfügung.");
            eins.Kopf = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Geben Sie den Durchmesser an");
            eins.Durchmesser = Console.ReadLine();
            eins.Schraubenkopf();

            Console.ReadKey();

        }
    }

    public class Schraubendefinition
    {

        public bool beenden;
        public string Material
        { get; set; }
        public string Art
        { get; set; }
        public string Durchmesser
        { get; set; }
        public double Schlusselweite
        { get; set; }
        public string Gewinde
        { get; set; }
        public string Gewinde_Zoll
        { get; set; }
        //public string Gewinde_Fein
        //{ get; set; }
        public string Gewinde_Trapez
        { get; set; }
        public string Kopf
        { get; set; }


        public bool MaterialAbfrage()
        {
            string abfrage = "Nochmal versuchen? (ja/nein)";
            Console.WriteLine("Bitte gewünschtes Material eingeben. Es stehen Stahl, Aluminium, Messing, Kupfer und Titan zur Verfügung.");
            Material = Convert.ToString(Console.ReadLine());
            //Ausgabe Material
            if (getDichte(Material) == 0)
            {
                Console.WriteLine(abfrage);
                string antwort = Console.ReadLine().Trim().ToLower();
                if (antwort != "ja")
                {

                    beenden = true;
                    Environment.Exit(0);
                }


            }
            else
            {
                beenden = true;
            }

            return beenden;
        }



        public void Ausgabe_Gewinde(Schraubendefinition eins)
        {
            var zahlen = eins.getDurchmesser();
            Console.WriteLine($"Der Durchmesser ist {zahlen._durchmesser}");
            Console.WriteLine($"Die Steigung ist {zahlen._steigung}");
            Console.WriteLine($"Der Kernlochdurchmesser ist {zahlen._kernloch}");
            Console.WriteLine($"Der Kerndurchmesser ist {zahlen._kern}");
            Console.WriteLine($"Der Flankendurchmesser ist {zahlen._flanken}");
        }

        public double getDichte(string material) // Methode um Dichte des jeweiligen Materials zu bekommen
        {
            double spezDichte = 0;
            switch (Material)
            {
                case "Stahl":
                    spezDichte = 7.85; // Hier bekommt  das Material seine Dichte
                    break;
                case "Aluminium":
                    spezDichte = 2.7;
                    break;
                case "Titan":
                    spezDichte = 4.507;
                    break;
                case "Messing":
                    spezDichte = 8.73;
                    break;
                case "Kupfer":
                    spezDichte = 8.96;
                    break;

                default: // Falls ein nicht aufgelistetes Material benutzt wird wird default ausgegeben
                    Console.WriteLine("Material leider nicht vorhanden, prüfe deine Rechtschreibung: " + Material);

                    break;
            }


            return spezDichte;
        }

        public (double _durchmesser, double _steigung, double _kernloch, double _kern, double _flanken) getDurchmesser() // Methode um Art/Variante der Schraube zu klären
        {
            Schraubendefinition eins = new Schraubendefinition();
            double spezDurchmesser = 0;
            double spezFlankendurchmesser = 0;
            double spezKerndurchmesser = 0;
            double spezKernlochdurchmesser = 0;
            double spezSteigung = 0;
            double spezSpiel = 0;

            switch (Art)
            {
                case "Metrisch":
                    {
                        Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von M1 bis M42 Schrauben zur Auswahl.");
                        Gewinde = Convert.ToString(Console.ReadLine());

                        if (Gewinde == "M1")
                        {
                            spezDurchmesser = 1; // Hier bekommt  das Gewinde seinen Durchmesser
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M1,2")
                        {
                            spezDurchmesser = 1.2;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M1,6")
                        {
                            spezDurchmesser = 1.6;
                            spezSteigung = 0.35;
                        }
                        else if (Gewinde == "M2")
                        {
                            spezDurchmesser = 2;
                            spezSteigung = 0.4;
                        }
                        else if (Gewinde == "M2,5")
                        {
                            spezDurchmesser = 2.5;
                            spezSteigung = 0.45;
                        }
                        else if (Gewinde == "M3")
                        {
                            spezDurchmesser = 3;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M4")
                        {
                            spezDurchmesser = 4;
                            spezSteigung = 0.7;
                        }
                        else if (Gewinde == "M5")
                        {
                            spezDurchmesser = 5;
                            spezSteigung = 0.8;
                        }
                        else if (Gewinde == "M6")
                        {
                            spezDurchmesser = 6;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M8")
                        {
                            spezDurchmesser = 8;
                            spezSteigung = 1.25;
                        }
                        else if (Gewinde == "M10")
                        {
                            spezDurchmesser = 10;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M12")
                        {
                            spezDurchmesser = 12;
                            spezSteigung = 1.75;
                        }
                        else if (Gewinde == "M16")
                        {
                            spezDurchmesser = 16;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M20")
                        {
                            spezDurchmesser = 20;
                            spezSteigung = 2.5;
                        }
                        else if (Gewinde == "M24")
                        {
                            spezDurchmesser = 24;
                            spezSteigung = 3;
                        }
                        else if (Gewinde == "M30")
                        {
                            spezDurchmesser = 30;
                            spezSteigung = 3.5;
                        }
                        else if (Gewinde == "M36")
                        {
                            spezDurchmesser = 36;
                            spezSteigung = 4;
                        }
                        else if (Gewinde == "M42")
                        {
                            spezDurchmesser = 42;
                            spezSteigung = 4.5;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe schein leider kein metrisches Regelgewinde zu sein.... " + Gewinde);
                        }

                        spezFlankendurchmesser = (spezDurchmesser - 0.6495 * spezSteigung);
                        spezKerndurchmesser = (spezDurchmesser - 1.2269 * spezSteigung);
                        spezKernlochdurchmesser = (spezDurchmesser - spezSteigung);

                        break;
                    }
                case "Metrisch Fein":
                    {
                        Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von M2x0,25 bis M42x2 Schrauben zur Auswahl.");
                        Gewinde = Convert.ToString(Console.ReadLine());

                        if (Gewinde == "M2x0,25")
                        {
                            spezDurchmesser = 2;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M3x0,25")
                        {
                            spezDurchmesser = 3;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M4x0,2")
                        {
                            spezDurchmesser = 4;
                            spezSteigung = 0.2;
                        }
                        else if (Gewinde == "M4x0,35")
                        {
                            spezDurchmesser = 4;
                            spezSteigung = 0.35;
                        }
                        else if (Gewinde == "M5x0,25")
                        {
                            spezDurchmesser = 5;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M5x0,5")
                        {
                            spezDurchmesser = 5;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M6x0,25")
                        {
                            spezDurchmesser = 6;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M6x0,5")
                        {
                            spezDurchmesser = 6;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M6x0,75")
                        {
                            spezDurchmesser = 6;
                            spezSteigung = 0.75;
                        }
                        else if (Gewinde == "M8x0,25")
                        {
                            spezDurchmesser = 8;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M8x0,5")
                        {
                            spezDurchmesser = 8;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M8x1")
                        {
                            spezDurchmesser = 8;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M10x0,25")
                        {
                            spezDurchmesser = 10;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M10x0,5")
                        {
                            spezDurchmesser = 10;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M10x1")
                        {
                            spezDurchmesser = 10;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M12x0,35")
                        {
                            spezDurchmesser = 12;
                            spezSteigung = 0.35;
                        }
                        else if (Gewinde == "M12x0,5")
                        {
                            spezDurchmesser = 12;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M12x1")
                        {
                            spezDurchmesser = 12;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M16x0,5")
                        {
                            spezDurchmesser = 16;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M16x1")
                        {
                            spezDurchmesser = 16;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M16x1,5")
                        {
                            spezDurchmesser = 16;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M20x1")
                        {
                            spezDurchmesser = 20;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M20x1,5")
                        {
                            spezDurchmesser = 20;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M24x1,5")
                        {
                            spezDurchmesser = 24;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M24x2")
                        {
                            spezDurchmesser = 24;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M30x1,5")
                        {
                            spezDurchmesser = 30;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M30x2")
                        {
                            spezDurchmesser = 30;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M36x1,5")
                        {
                            spezDurchmesser = 36;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M36x2")
                        {
                            spezDurchmesser = 36;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M42x1,5")
                        {
                            spezDurchmesser = 42;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M42x2")
                        {
                            spezDurchmesser = 42;
                            spezSteigung = 2;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe schein leider kein metrisches Feingewinde zu sein.... " + Gewinde);
                        }

                        spezFlankendurchmesser = (spezDurchmesser - 0.6495 * spezSteigung);
                        spezKerndurchmesser = (spezDurchmesser - 1.2269 * spezSteigung);
                        spezKernlochdurchmesser = (spezDurchmesser - spezSteigung);

                        break;
                    }
                case "Zoll":
                    {
                        Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von 1/4 bis 2 Zoll-Schrauben zur Auswahl." + '\n' + "Bsp. Schreibweise: 1 1/2");
                        Gewinde_Zoll = Convert.ToString(Console.ReadLine());

                        if (Gewinde_Zoll == "1/4")
                        {
                            spezDurchmesser = 6.35;
                            spezSteigung = 0.907;
                            spezFlankendurchmesser = 5.54;
                            spezKerndurchmesser = 4.72;
                            spezKernlochdurchmesser = 5.1;
                        }
                        else if (Gewinde_Zoll == "3/8")
                        {
                            spezDurchmesser = 9.525;
                            spezSteigung = 1.058;
                            spezFlankendurchmesser = 8.51;
                            spezKerndurchmesser = 7.49;
                            spezKernlochdurchmesser = 7.9;
                        }
                        else if (Gewinde_Zoll == "1/2")
                        {
                            spezDurchmesser = 12.7;
                            spezSteigung = 1.27;
                            spezFlankendurchmesser = 11.35;
                            spezKerndurchmesser = 9.99;
                            spezKernlochdurchmesser = 10.5;
                        }
                        else if (Gewinde_Zoll == "3/4")
                        {
                            spezDurchmesser = 19.05;
                            spezSteigung = 1.587;
                            spezFlankendurchmesser = 17.42;
                            spezKerndurchmesser = 15.8;
                            spezKernlochdurchmesser = 16.3;
                        }
                        else if (Gewinde_Zoll == "1")
                        {
                            spezDurchmesser = 25.4;
                            spezSteigung = 2.117;
                            spezFlankendurchmesser = 17.42;
                            spezKerndurchmesser = 21.34;
                            spezKernlochdurchmesser = 16.3;
                        }
                        else if (Gewinde_Zoll == "1 1/4")
                        {
                            spezDurchmesser = 31.75;
                            spezSteigung = 3.629;
                            spezFlankendurchmesser = 29.43;
                            spezKerndurchmesser = 27.1;
                            spezKernlochdurchmesser = 28;
                        }
                        else if (Gewinde_Zoll == "1 1/2")
                        {
                            spezDurchmesser = 38.1;
                            spezSteigung = 4.23;
                            spezFlankendurchmesser = 35.39;
                            spezKerndurchmesser = 32.68;
                            spezKernlochdurchmesser = 33.5;
                        }
                        else if (Gewinde_Zoll == "2")
                        {
                            spezDurchmesser = 50.8;
                            spezSteigung = 5.64;
                            spezFlankendurchmesser = 47.19;
                            spezKerndurchmesser = 43.57;
                            spezKernlochdurchmesser = 44.5;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe scheint leider kein vorhandenes Zollgewinde zu sein.... " + Gewinde_Zoll);
                        }

                        break;
                    }
                case "Trapez":
                    {
                        Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von Tr10x2 bis Tr36x6 -Schrauben zur Auswahl. ");
                        Gewinde_Trapez = Convert.ToString(Console.ReadLine());

                        if (Gewinde_Trapez == "Tr10x2")
                        {
                            spezDurchmesser = 10;
                            spezSteigung = 2;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr12x3")
                        {
                            spezDurchmesser = 12;
                            spezSteigung = 3;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr16x4")
                        {
                            spezDurchmesser = 16;
                            spezSteigung = 4;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr20x4")
                        {
                            spezDurchmesser = 20;
                            spezSteigung = 4;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr24x5")
                        {
                            spezDurchmesser = 24;
                            spezSteigung = 5;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr28x5")
                        {
                            spezDurchmesser = 28;
                            spezSteigung = 5;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr32x6")
                        {
                            spezDurchmesser = 32;
                            spezSteigung = 6;
                            spezSpiel = 0.5;
                        }
                        else if (Gewinde_Zoll == "Tr36x6")
                        {
                            spezDurchmesser = 36;
                            spezSteigung = 6;
                            spezSpiel = 0.5;
                        }
                        else if (Gewinde_Zoll == "Tr40x7")
                        {
                            spezDurchmesser = 40;
                            spezSteigung = 7;
                            spezSpiel = 0.5;
                        }
                        else if (Gewinde_Zoll == "Tr44x7")
                        {
                            spezDurchmesser = 44;
                            spezSteigung = 7;
                            spezSpiel = 0.5;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe scheint leider kein metrisches Trapezgewinde zu sein.... " + Gewinde_Trapez);
                        }

                        spezFlankendurchmesser = (spezDurchmesser - 0.5 * spezSteigung);
                        spezKerndurchmesser = (spezDurchmesser - (2 * spezSpiel + spezSteigung));

                        break;
                    }


                default:
                    break;

            }

            return (_durchmesser: spezDurchmesser, _steigung: spezSteigung, _kernloch: spezKernlochdurchmesser, _kern: spezKerndurchmesser, _flanken: spezFlankendurchmesser);
        }

        public double Schraubenkopf() //Methode um Schraubenkopf zu wählen.
        {


            switch (Kopf)
            {
                case "Sechskant":
                    {
                        if (Durchmesser == "2,5")
                        {
                            Console.WriteLine("Schlüsselweite SW=5mm");
                        }
                        if (Durchmesser == "3")
                        {
                            Console.WriteLine("Schlüsselweite SW=5,5mm");
                        }
                        if (Durchmesser == "4")
                        {
                            Console.WriteLine("Schlüsselweite SW=7mm");
                        }
                        if (Durchmesser == "5")
                        {
                            Console.WriteLine("Schlüsselweite SW=8mm");
                            return Schlusselweite = 8;
                        }
                        if (Durchmesser == "6")
                        {
                            Console.WriteLine("Schlüsselweite SW=10mm");
                        }
                        if (Durchmesser == "8")
                        {
                            Console.WriteLine("Schlüsselweite SW=13mm");
                        }
                        if (Durchmesser == "10")
                        {
                            Console.WriteLine("tSchlüsselweite SW=17mm");
                        }
                        if (Durchmesser == "12")
                        {
                            Console.WriteLine("Schlüsselweite SW=19mm");
                        }
                        if (Durchmesser == "16")
                        {
                            Console.WriteLine("Schlüsselweite SW=24mm");
                        }
                        break;
                    }


                case "Zylindrisch":
                    {
                        if (Durchmesser == "3")
                        {
                            Console.WriteLine("Innensechskant s=2,5mm");
                        }
                        if (Durchmesser == "4")
                        {
                            Console.WriteLine("Innensechskant s=3mm");
                        }
                        if (Durchmesser == "5")
                        {
                            Console.WriteLine("Innensechskant s=4mm");
                        }
                        if (Durchmesser == "6")
                        {
                            Console.WriteLine("Innensechskant s=5mm");
                        }
                        if (Durchmesser == "8")
                        {
                            Console.WriteLine("Innensechskant s=6mm");
                        }
                        if (Durchmesser == "10")
                        {
                            Console.WriteLine("Innensechskant s=8mm");
                        }
                        if (Durchmesser == "12")
                        {
                            Console.WriteLine("Innensechskant s=10mm");
                        }
                        if (Durchmesser == "16")
                        {
                            Console.WriteLine("Innensechskant s=14mm");
                        }
                        break;
                    }

                case "Senkkopf":
                    {
                        if (Durchmesser == "2")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 1");
                        }
                        if (Durchmesser == "2,5")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 1");
                        }
                        if (Durchmesser == "3")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 1");
                        }
                        if (Durchmesser == "4")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 2");
                        }
                        if (Durchmesser == "5")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 2");
                        }
                        if (Durchmesser == "6")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 3");
                        }
                        if (Durchmesser == "8")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 4");
                        }
                        if (Durchmesser == "10")
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 4");
                        }

                    }
                    break;

                default:
                    Console.WriteLine("Schraubenkopf leider nicht vorhanden, prüfe Rechtschreibung " + Kopf);
                    break;
            }
            return Schlusselweite;
        }










    }

}