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

        public List<string> SchraubenfestigkeitStahl { get; set; }
        public List<string> SchraubenfestigkeitAlu { get; set; }
        public List<string> SchraubenfestigkeitTit { get; set; }
        public List<string> SchraubenfestigkeitKup{ get; set; }
        public List<string> SchraubenfestigkeitMesBro{ get; set; }




        public List<string> Kopfform { get; set; }



        public GUItools()
        {
            #region Combobox-Sammlung

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
            }

            MaterialSammlung = new List<string>();
            {
                MaterialSammlung.Add("Stahl");
                MaterialSammlung.Add("Aluminium");
                MaterialSammlung.Add("Titan");
                MaterialSammlung.Add("Messing");
                MaterialSammlung.Add("Bronze");
                MaterialSammlung.Add("Kupfer");
            }

            ArtenSammlung = new List<string>();
            {
                ArtenSammlung.Add("Metrisch");
                ArtenSammlung.Add("Metrisch_Fein");
                ArtenSammlung.Add("Zoll");
            }

            Kopfform = new List<string>();
            {
                Kopfform.Add("Sechskant");
                Kopfform.Add("Zylinderkopf");
                Kopfform.Add("Senkkopf");
            }

            SchraubenfestigkeitStahl = new List<string>();
            {
                SchraubenfestigkeitStahl.Add("3.6");
                SchraubenfestigkeitStahl.Add("4.6");
                SchraubenfestigkeitStahl.Add("4.8");
                SchraubenfestigkeitStahl.Add("5.8");
                SchraubenfestigkeitStahl.Add("6.8");
                SchraubenfestigkeitStahl.Add("8.8");
                SchraubenfestigkeitStahl.Add("9.8");
                SchraubenfestigkeitStahl.Add("10.9");
                SchraubenfestigkeitStahl.Add("12.9");
            }

            SchraubenfestigkeitAlu = new List<string>();
            {
                SchraubenfestigkeitAlu.Add("3.6");
                SchraubenfestigkeitAlu.Add("4.6");
                SchraubenfestigkeitAlu.Add("4.8");
                SchraubenfestigkeitAlu.Add("5.8");
            }

            SchraubenfestigkeitTit = new List<string>();
            {
                SchraubenfestigkeitTit.Add("3.6");
                SchraubenfestigkeitTit.Add("4.6");
                SchraubenfestigkeitTit.Add("4.8");
                SchraubenfestigkeitTit.Add("5.8");
                SchraubenfestigkeitTit.Add("6.8");
                SchraubenfestigkeitTit.Add("8.8");
            }

            SchraubenfestigkeitMesBro = new List<string>();
            {
                SchraubenfestigkeitMesBro.Add("3.6");
                SchraubenfestigkeitMesBro.Add("4.6");
            }

            SchraubenfestigkeitKup = new List<string>();
            {
                SchraubenfestigkeitKup.Add("3.6");
                SchraubenfestigkeitKup.Add("4.6");
                SchraubenfestigkeitKup.Add("4.8");
            }

            #endregion
        }

    }
}
