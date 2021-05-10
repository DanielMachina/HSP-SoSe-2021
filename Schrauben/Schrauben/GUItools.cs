using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrauben
{
    class GUItools
    {
        public List<string> GewindeSammlung { get; set; }

        public List<string> MaterialSammlung { get; set; }

        public List<string> ArtenSammlung { get; set; }

        public List<string> Schraubenfestigkeit { get; set; }
        public string Begrüßung { get; set; }

        public List<string> Kopfform { get; set; }
        public GUItools()
        {
            Begrüßung = "Hallo, das ist unser Schraubenkonfigurator";

            GewindeSammlung = new List<string>();
            {
                GewindeSammlung.Add("M1,6");
                GewindeSammlung.Add("M2");
                GewindeSammlung.Add("M2,5");
                GewindeSammlung.Add("M3");
                GewindeSammlung.Add("M4");
                GewindeSammlung.Add("M5");
                GewindeSammlung.Add("M6");
                GewindeSammlung.Add("M8");
                GewindeSammlung.Add("M10");
                GewindeSammlung.Add("M12");
                GewindeSammlung.Add("M16");
                GewindeSammlung.Add("M20");
                GewindeSammlung.Add("M24");
                GewindeSammlung.Add("M30");
                GewindeSammlung.Add("M36");
                GewindeSammlung.Add("M42");
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
                ArtenSammlung.Add("Metrisch Fein");
                ArtenSammlung.Add("Zoll");
            }

            Kopfform = new List<string>();
            {
                Kopfform.Add("Sechskant");
                Kopfform.Add("Zylinderkopf");
                Kopfform.Add("Senkkopf");
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
            }
        }

    }
}
