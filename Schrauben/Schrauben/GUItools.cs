using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{
    public class GUItools
    {
        
        public static List<string> MetrischSammlung { get; set; } 
        public List<string> FeinMetrischSammlung { get; set; } 
        public List<string> ZollSammlung { get; set; }
        public static List<string> GewindeSammlung { get; set; }

        public List<string> MaterialSammlung { get; set; }

        public List<string> ArtenSammlung { get; set; }

        public List<string> Schraubenfestigkeit { get; set; }



        public List<string> Kopfform { get; set; }



        public GUItools()
        {


            MetrischSammlung = new List<string>();
            {
                MetrischSammlung.Add("M2");
                MetrischSammlung.Add("M2,5");
                MetrischSammlung.Add("M3");
                MetrischSammlung.Add("M4");
                MetrischSammlung.Add("M5");
                MetrischSammlung.Add("M6");
                MetrischSammlung.Add("M8");
                MetrischSammlung.Add("M10");
                MetrischSammlung.Add("M12");
                MetrischSammlung.Add("M16");
                MetrischSammlung.Add("M20");
                MetrischSammlung.Add("M24");
                MetrischSammlung.Add("M30");
                MetrischSammlung.Add("M36");
                MetrischSammlung.Add("M42");
                MetrischSammlung.Add("");
            }

            ZollSammlung = new List<string>();
            {
                ZollSammlung.Add("1/4");
                ZollSammlung.Add("3/8");
                ZollSammlung.Add("1/2");
                ZollSammlung.Add("3/4");
                ZollSammlung.Add("1");
                ZollSammlung.Add("1 1/4");
                ZollSammlung.Add("1 1/2");
                ZollSammlung.Add("");
            }

            FeinMetrischSammlung = new List<string>();
            {
                FeinMetrischSammlung.Add("M2x0,25");
                FeinMetrischSammlung.Add("M3x0,25");
                FeinMetrischSammlung.Add("M4x0,2");
                FeinMetrischSammlung.Add("M4x0,35");
                FeinMetrischSammlung.Add("M5x0,25");
                FeinMetrischSammlung.Add("M5x0,5");
                FeinMetrischSammlung.Add("M6x0,25");
                FeinMetrischSammlung.Add("M6x0,5");
                FeinMetrischSammlung.Add("M6x0,75");
                FeinMetrischSammlung.Add("M8x0,25");
                FeinMetrischSammlung.Add("M8x0,5");
                FeinMetrischSammlung.Add("M8x1");
                FeinMetrischSammlung.Add("M10x0,25");
                FeinMetrischSammlung.Add("M10x0,5");
                FeinMetrischSammlung.Add("M10x1");
                FeinMetrischSammlung.Add("M12x0,35");
                FeinMetrischSammlung.Add("M12x0,5");
                FeinMetrischSammlung.Add("M12x1");
                FeinMetrischSammlung.Add("M16x0,5");
                FeinMetrischSammlung.Add("M16x1");
                FeinMetrischSammlung.Add("M16x1,5");
                FeinMetrischSammlung.Add("M20x1");
                FeinMetrischSammlung.Add("M20x1,5");
                FeinMetrischSammlung.Add("M24x1,5");
                FeinMetrischSammlung.Add("M24x2");
                FeinMetrischSammlung.Add("M30x1,5");
                FeinMetrischSammlung.Add("M30x2");
                FeinMetrischSammlung.Add("M36x1,5");
                FeinMetrischSammlung.Add("M36x2");
                FeinMetrischSammlung.Add("M42x1,5");
                FeinMetrischSammlung.Add("M42x2");
                FeinMetrischSammlung.Add("");
            }

            MaterialSammlung = new List<string>();
            {
                MaterialSammlung.Add("Stahl");
                MaterialSammlung.Add("Aluminium");
                MaterialSammlung.Add("Titan");
                MaterialSammlung.Add("Messing");
                MaterialSammlung.Add("Bronze");
                MaterialSammlung.Add("Kupfer");
                MaterialSammlung.Add("");
            }

            ArtenSammlung = new List<string>();
            {
                ArtenSammlung.Add("Metrisch");
                ArtenSammlung.Add("Metrisch_Fein");
                ArtenSammlung.Add("Zoll");
                ArtenSammlung.Add("");
            }

            Kopfform = new List<string>();
            {
                Kopfform.Add("Sechskant");
                Kopfform.Add("Zylinderkopf");
                Kopfform.Add("Senkkopf");
                Kopfform.Add("");
            }

            Schraubenfestigkeit = new List<string>();
            {
                Schraubenfestigkeit.Add("3.6");
                Schraubenfestigkeit.Add("4.6");
                Schraubenfestigkeit.Add("4.8");
                Schraubenfestigkeit.Add("5.8");
                Schraubenfestigkeit.Add("6.8");
                Schraubenfestigkeit.Add("8.8");
                Schraubenfestigkeit.Add("9.8");
                Schraubenfestigkeit.Add("10.9");
                Schraubenfestigkeit.Add("12.9");
                Schraubenfestigkeit.Add("");
            }
        }

    }
}
