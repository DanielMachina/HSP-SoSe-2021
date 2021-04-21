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
            string antwort;   
            Schraubendefinition eins = new Schraubendefinition();
            Tools tool = new Tools();
            //Eingabe Material
            do
            {
                tool.Abfrage("Material" , "Stahl, Aluminium, Messing, Kupfer und Titan");
                eins.getMaterial();
            } while (eins.beenden != true);


            //Eingabe Schraubenart
            do
            {
                tool.Abfrage("Schraubenart", "Metrisch, Metrisch Fein, Zoll, Trapez - gewinde");
                eins.Art = Convert.ToString(Console.ReadLine());
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
                tool.Ausgabe_Gewinde(eins);
                if (eins.Durchmesser == 0)
                {

                    Console.WriteLine(eins.wiederholung);
                    antwort = Console.ReadLine().Trim().ToLower();
                    if (antwort == "nein")
                    { Environment.Exit(0); }

                }
                else { break; }

            } while (true);

            //Eingabe Laenge
            tool.Abfrage("Länge in mm","") ;
            eins.Laenge = Convert.ToDouble(Console.ReadLine());

            //Eingabe Schraubenkopf
            do
            {
                tool.Abfrage("Schraubenkopf", "Sechskant, Zylindrisch und Senkkopf");

                eins.Schraubenkopf();
                if(eins.Schlüsselweite == 0)
                {
                    Console.WriteLine(eins.wiederholung);
                    antwort = Console.ReadLine().Trim().ToLower();
                    if (antwort == "nein")
                    {
                        Environment.Exit(0);
                    }

                }
                else { break; }
            } while (true);

            //Berechnung Volumen
            eins.Volumen = eins.Laenge * Math.Pow(eins.Durchmesser, 2) * (Math.PI / 4);

            //Berechnung Masse, Ausgabe Masse
            eins.Masse = eins.getDichte(eins.Material) * eins.Volumen / 1000; // Menge
            Console.WriteLine($"Die Masse ist {eins.Masse} Gramm");

            //Mengeneingabe und Gesamtgewicht
            tool.Abfrage("Menge", "");
            eins.Menge = Convert.ToInt32(Console.ReadLine());
            eins.Gesamtmasse = eins.Masse * eins.Menge; //Gesamtgewicht aus Einzelmasse und Menge
            Console.WriteLine($"Die Gesamtmasse ist {eins.Gesamtmasse} Gramm");

            Console.ReadKey();
        }
    }

    public class Tools // zur vereinfacherung
    {
        public void Abfrage(string element, string auswahl) // Abfrage von Element und Auswahl 
        {
            if (auswahl != "")
            {
                Console.WriteLine($"Bitte {element} angeben");
                Console.WriteLine($"Es stehen {auswahl} zur verfügung");
            }
            else
            {
                Console.WriteLine($"Bitte {element} angeben");
            }
        }

        public void Ausgabe_Gewinde(Schraubendefinition eins)
        {
            var zahlen = eins.getDurchmesser();
            Console.WriteLine($"Der Durchmesser ist {zahlen._durchmesser}");
        }
    }

    public class Schraubendefinition
    {
        Tools tool = new Tools();

        public bool beenden;
        public string wiederholung = "Nochmal versuchen? (ja/nein)";
        // Eigenschaften
        public double Laenge
        { get; set; }
        public string Material
        { get; set; }
        public string Art
        { get; set; }
        public double Durchmesser
        { get; set; }
        public double Schlüsselweite
        { get; set; }
        public string Gewinde
        { get; set; }
        public string Gewinde_Zoll
        { get; set; }
        public string Gewinde_Trapez
        { get; set; }
        public string Kopf
        { get; set; }
        public double Volumen // ohne Schraubenkopf
        { get; set; }
        public double Masse
        { get; set; }
        public double Menge
        { get; set; }
        public double Gesamtmasse
        { get; set; }
        public double Kopfhöhe
        { get; set; }




        public bool getMaterial()
        {
            
            Material = Convert.ToString(Console.ReadLine());

            if (getDichte(Material) == 0)
            {
                Console.WriteLine(wiederholung);
                string antwort = Console.ReadLine().Trim().ToLower();
                if (antwort != "ja")
                {
                    Environment.Exit(0);
                }
     
     
            }
            else
            {
                beenden = true;
            }
     
            return beenden;
        }


        public double getDichte(string Material) // Methode um Dichte des jeweiligen Materials zu bekommen
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

            double spezFlankendurchmesser = 0;
            double spezKerndurchmesser = 0;
            double spezKernlochdurchmesser = 0;
            double spezSteigung = 0;
            double spezSpiel = 0;

            switch (Art)
            {
                case "Metrisch":
                    {
                        tool.Abfrage("Gewindedurchmesser","M1,6 bis M42");
                        Gewinde = Convert.ToString(Console.ReadLine());

                        
                        if (Gewinde == "M1,6")
                        {
                            Durchmesser = 1.6;
                            spezSteigung = 0.35;
                        }
                        else if (Gewinde == "M2")
                        {
                            Durchmesser = 2;
                            spezSteigung = 0.4;
                        }
                        else if (Gewinde == "M2,5")
                        {
                            Durchmesser = 2.5;
                            spezSteigung = 0.45;
                        }
                        else if (Gewinde == "M3")
                        {
                            Durchmesser = 3;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M4")
                        {
                            Durchmesser = 4;
                            spezSteigung = 0.7;
                        }
                        else if (Gewinde == "M5")
                        {
                            Durchmesser = 5;
                            spezSteigung = 0.8;
                        }
                        else if (Gewinde == "M6")
                        {
                            Durchmesser = 6;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M8")
                        {
                            Durchmesser = 8;
                            spezSteigung = 1.25;
                        }
                        else if (Gewinde == "M10")
                        {
                            Durchmesser = 10;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M12")
                        {
                            Durchmesser = 12;
                            spezSteigung = 1.75;
                        }
                        else if (Gewinde == "M16")
                        {
                            Durchmesser = 16;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M20")
                        {
                            Durchmesser = 20;
                            spezSteigung = 2.5;
                        }
                        else if (Gewinde == "M24")
                        {
                            Durchmesser = 24;
                            spezSteigung = 3;
                        }
                        else if (Gewinde == "M30")
                        {
                            Durchmesser = 30;
                            spezSteigung = 3.5;
                        }
                        else if (Gewinde == "M36")
                        {
                            Durchmesser = 36;
                            spezSteigung = 4;
                        }
                        else if (Gewinde == "M42")
                        {
                            Durchmesser = 42;
                            spezSteigung = 4.5;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe scheint leider kein metrisches Regelgewinde zu sein.... " + Gewinde);
                        }

                        spezFlankendurchmesser = (Durchmesser - 0.6495 * spezSteigung);
                        spezKerndurchmesser = (Durchmesser - 1.2269 * spezSteigung);
                        spezKernlochdurchmesser = (Durchmesser - spezSteigung);

                        break;
                    }
                case "Metrisch Fein":
                    {
                        tool.Abfrage("Gewindedurchmesser", "M2x0,25 bis M42x2");
                        Gewinde = Convert.ToString(Console.ReadLine());

                        if (Gewinde == "M2x0,25")
                        {
                            Durchmesser = 2;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M3x0,25")
                        {
                            Durchmesser = 3;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M4x0,2")
                        {
                            Durchmesser = 4;
                            spezSteigung = 0.2;
                        }
                        else if (Gewinde == "M4x0,35")
                        {
                            Durchmesser = 4;
                            spezSteigung = 0.35;
                        }
                        else if (Gewinde == "M5x0,25")
                        {
                            Durchmesser = 5;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M5x0,5")
                        {
                            Durchmesser = 5;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M6x0,25")
                        {
                            Durchmesser = 6;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M6x0,5")
                        {
                            Durchmesser = 6;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M6x0,75")
                        {
                            Durchmesser = 6;
                            spezSteigung = 0.75;
                        }
                        else if (Gewinde == "M8x0,25")
                        {
                            Durchmesser = 8;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M8x0,5")
                        {
                            Durchmesser = 8;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M8x1")
                        {
                            Durchmesser = 8;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M10x0,25")
                        {
                            Durchmesser = 10;
                            spezSteigung = 0.25;
                        }
                        else if (Gewinde == "M10x0,5")
                        {
                            Durchmesser = 10;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M10x1")
                        {
                            Durchmesser = 10;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M12x0,35")
                        {
                            Durchmesser = 12;
                            spezSteigung = 0.35;
                        }
                        else if (Gewinde == "M12x0,5")
                        {
                            Durchmesser = 12;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M12x1")
                        {
                            Durchmesser = 12;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M16x0,5")
                        {
                            Durchmesser = 16;
                            spezSteigung = 0.5;
                        }
                        else if (Gewinde == "M16x1")
                        {
                            Durchmesser = 16;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M16x1,5")
                        {
                            Durchmesser = 16;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M20x1")
                        {
                            Durchmesser = 20;
                            spezSteigung = 1;
                        }
                        else if (Gewinde == "M20x1,5")
                        {
                            Durchmesser = 20;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M24x1,5")
                        {
                            Durchmesser = 24;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M24x2")
                        {
                            Durchmesser = 24;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M30x1,5")
                        {
                            Durchmesser = 30;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M30x2")
                        {
                            Durchmesser = 30;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M36x1,5")
                        {
                            Durchmesser = 36;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M36x2")
                        {
                            Durchmesser = 36;
                            spezSteigung = 2;
                        }
                        else if (Gewinde == "M42x1,5")
                        {
                            Durchmesser = 42;
                            spezSteigung = 1.5;
                        }
                        else if (Gewinde == "M42x2")
                        {
                            Durchmesser = 42;
                            spezSteigung = 2;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe schein leider kein metrisches Feingewinde zu sein.... " + Gewinde);
                        }

                        spezFlankendurchmesser = (Durchmesser - 0.6495 * spezSteigung);
                        spezKerndurchmesser = (Durchmesser - 1.2269 * spezSteigung);
                        spezKernlochdurchmesser = (Durchmesser - spezSteigung);

                        break;
                    }
                case "Zoll":
                    {
                        Console.WriteLine("Bitte geben Sie Ihren gewünschten Gewindedurchmesser an. Es gibt von 1/4 bis 2 Zoll-Schrauben zur Auswahl." + '\n' + "Bsp. Schreibweise: 1 1/2");
                        Gewinde_Zoll = Convert.ToString(Console.ReadLine());

                        if (Gewinde_Zoll == "1/4")
                        {
                            Durchmesser = 6.35;
                            spezSteigung = 0.907;
                            spezFlankendurchmesser = 5.54;
                            spezKerndurchmesser = 4.72;
                            spezKernlochdurchmesser = 5.1;
                        }
                        else if (Gewinde_Zoll == "3/8")
                        {
                            Durchmesser = 9.525;
                            spezSteigung = 1.058;
                            spezFlankendurchmesser = 8.51;
                            spezKerndurchmesser = 7.49;
                            spezKernlochdurchmesser = 7.9;
                        }
                        else if (Gewinde_Zoll == "1/2")
                        {
                            Durchmesser = 12.7;
                            spezSteigung = 1.27;
                            spezFlankendurchmesser = 11.35;
                            spezKerndurchmesser = 9.99;
                            spezKernlochdurchmesser = 10.5;
                        }
                        else if (Gewinde_Zoll == "3/4")
                        {
                            Durchmesser = 19.05;
                            spezSteigung = 1.587;
                            spezFlankendurchmesser = 17.42;
                            spezKerndurchmesser = 15.8;
                            spezKernlochdurchmesser = 16.3;
                        }
                        else if (Gewinde_Zoll == "1")
                        {
                            Durchmesser = 25.4;
                            spezSteigung = 2.117;
                            spezFlankendurchmesser = 17.42;
                            spezKerndurchmesser = 21.34;
                            spezKernlochdurchmesser = 16.3;
                        }
                        else if (Gewinde_Zoll == "1 1/4")
                        {
                            Durchmesser = 31.75;
                            spezSteigung = 3.629;
                            spezFlankendurchmesser = 29.43;
                            spezKerndurchmesser = 27.1;
                            spezKernlochdurchmesser = 28;
                        }
                        else if (Gewinde_Zoll == "1 1/2")
                        {
                            Durchmesser = 38.1;
                            spezSteigung = 4.23;
                            spezFlankendurchmesser = 35.39;
                            spezKerndurchmesser = 32.68;
                            spezKernlochdurchmesser = 33.5;
                        }
                        else if (Gewinde_Zoll == "2")
                        {
                            Durchmesser = 50.8;
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
                        tool.Abfrage("Gewindedurchmesser", "Tr10x2 bis Tr36x6");
                        Gewinde_Trapez = Convert.ToString(Console.ReadLine());

                        if (Gewinde_Trapez == "Tr10x2")
                        {
                            Durchmesser = 10;
                            spezSteigung = 2;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr12x3")
                        {
                            Durchmesser = 12;
                            spezSteigung = 3;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr16x4")
                        {
                            Durchmesser = 16;
                            spezSteigung = 4;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr20x4")
                        {
                            Durchmesser = 20;
                            spezSteigung = 4;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr24x5")
                        {
                            Durchmesser = 24;
                            spezSteigung = 5;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr28x5")
                        {
                            Durchmesser = 28;
                            spezSteigung = 5;
                            spezSpiel = 0.25;
                        }
                        else if (Gewinde_Zoll == "Tr32x6")
                        {
                            Durchmesser = 32;
                            spezSteigung = 6;
                            spezSpiel = 0.5;
                        }
                        else if (Gewinde_Zoll == "Tr36x6")
                        {
                            Durchmesser = 36;
                            spezSteigung = 6;
                            spezSpiel = 0.5;
                        }
                        else if (Gewinde_Zoll == "Tr40x7")
                        {
                            Durchmesser = 40;
                            spezSteigung = 7;
                            spezSpiel = 0.5;
                        }
                        else if (Gewinde_Zoll == "Tr44x7")
                        {
                            Durchmesser = 44;
                            spezSteigung = 7;
                            spezSpiel = 0.5;
                        }
                        else
                        {
                            Console.WriteLine("Ihre Eingabe scheint leider kein metrisches Trapezgewinde zu sein.... " + Gewinde_Trapez);
                        }

                        spezFlankendurchmesser = (Durchmesser - 0.5 * spezSteigung);
                        spezKerndurchmesser = (Durchmesser - (2 * spezSpiel + spezSteigung));

                        break;
                    }


                default:
                    break;

            }

            return (_durchmesser: Durchmesser, _steigung: spezSteigung, _kernloch: spezKernlochdurchmesser, _kern: spezKerndurchmesser, _flanken: spezFlankendurchmesser);
        }

        public (double _schlüsselweite, double _kopfhöhe) Schraubenkopf() //Methode um Schraubenkopf zu wählen.
        {
            Schlüsselweite = 0;
            Kopfhöhe = 0;
            Kopf = Convert.ToString(Console.ReadLine());
            switch (Kopf)
            {
                case "Sechskant": //sechskant zoll, sechskant metrisch
                    {
                        if (Durchmesser < 1.6)
                        {
                            Console.WriteLine("Der gewählte Durchmesser ist leider zu klein, der kleinstmögliche Durchmesser ist 2,0");
                            Schlüsselweite = 0;
                        }
                        else if (Durchmesser==1.6)
                        {
                            Schlüsselweite = 3.2;
                            Kopfhöhe = 1.1;
                        }
                        else if (Durchmesser == 2.0)
                        {
                            Schlüsselweite = 4;
                            Kopfhöhe = 1.4;
                        }

                        else if (Durchmesser == 2.5)
                        {
                            Schlüsselweite = 5;
                            Kopfhöhe = 1.7;
                        }
                        else if (Durchmesser == 3)
                        {
                            Schlüsselweite = 5.5;
                            Kopfhöhe = 2;
                        }
                        else if (Durchmesser == 4)
                        {
                            Schlüsselweite = 7;
                            Kopfhöhe = 2.8;
                        }
                        else if (Durchmesser == 5)
                        {
                            Schlüsselweite = 8;
                            Kopfhöhe = 3.5;
                        }
                        else if (Durchmesser == 6)
                        {
                            Schlüsselweite = 10;
                            Kopfhöhe = 4;
                        }
                        else if (Durchmesser == 8)
                        {
                            Schlüsselweite = 13;
                            Kopfhöhe = 5.3;
                        }
                        else if (Durchmesser == 10)
                        {
                            Schlüsselweite = 17;
                            Kopfhöhe = 6.4;
                        }
                        else if (Durchmesser == 12)
                        {
                            Schlüsselweite = 19;
                            Kopfhöhe = 7.5;
                        }
                        else if (Durchmesser == 16)
                        {
                            Schlüsselweite = 24;
                            Kopfhöhe = 10;
                        }
                        else if (Durchmesser == 20)
                        {
                            Schlüsselweite = 30;
                            Kopfhöhe = 12.5;
                        }
                        
                        else if (Durchmesser == 24)
                        {
                            Schlüsselweite = 36;
                            Kopfhöhe = 15;
                        }
                        else if (Durchmesser == 30)
                        {
                            Schlüsselweite = 46;
                            Kopfhöhe = 18.7;
                        }
                        else if (Durchmesser == 36)
                        {
                            Schlüsselweite = 55;
                            Kopfhöhe = 22.5;
                        }        
                        else if (Durchmesser == 42)
                        {
                            Schlüsselweite = 65;
                            Kopfhöhe = 26;
                        }            

                        break;
                    }


                case "Zylindrisch":
                    {
                        if (Durchmesser == 3)
                        {
                            Console.WriteLine("Innensechskant s=2,5mm");
                            Schlüsselweite = 2.5;
                        }  
                        else if (Durchmesser == 4)
                        {
                            Console.WriteLine("Innensechskant s=3mm");
                            Schlüsselweite = 3;
                        }
                        else if (Durchmesser == 5)
                        {
                            Console.WriteLine("Innensechskant s=4mm");
                            Schlüsselweite = 4;
                        }
                        else if (Durchmesser == 6)
                        {
                            Console.WriteLine("Innensechskant s=5mm");
                            Schlüsselweite = 5;
                        }
                        else if (Durchmesser == 8)
                        {
                            Console.WriteLine("Innensechskant s=6mm");
                            Schlüsselweite = 6;
                        }
                        else if (Durchmesser == 10)
                        {
                            Console.WriteLine("Innensechskant s=8mm");
                            Schlüsselweite = 8;
                        }
                        else if (Durchmesser == 12)
                        {
                            Console.WriteLine("Innensechskant s=10mm");
                            Schlüsselweite = 10;
                        }
                        else if (Durchmesser == 16)
                        {
                            Console.WriteLine("Innensechskant s=14mm");
                            Schlüsselweite = 14;
                        }
                        break;
                    }

                case "Senkkopf":
                    {
                        if (Durchmesser == 2)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 1");
                            Schlüsselweite = 1;
                        }
                        else if (Durchmesser == 2.5)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 1");
                            Schlüsselweite = 1;
                        }
                        else if (Durchmesser == 3)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 1");
                            Schlüsselweite = 1;
                        }
                        else if (Durchmesser == 4)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 2");
                            Schlüsselweite = 2;
                        }
                        else if (Durchmesser == 5)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 2");
                            Schlüsselweite = 2;
                        }
                        else if (Durchmesser == 6)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 3");
                            Schlüsselweite = 3;
                        }
                        else if (Durchmesser == 8)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 4");
                            Schlüsselweite = 4;
                        }
                        else if (Durchmesser == 10)
                        {
                            Console.WriteLine("Kreuzschlitz Gröse 4");
                            Schlüsselweite = 4;
                        }
                        
                    }
                    break;

                default:
                    Console.WriteLine("Schraubenkopf leider nicht vorhanden, prüfe Rechtschreibung " + Kopf);
                    break;
            }
            Console.WriteLine($"SW ={Schlüsselweite} ");
            return (_schlüsselweite: Schlüsselweite, _kopfhöhe: Kopfhöhe);
        }

    }
   
}
