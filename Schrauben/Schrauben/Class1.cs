using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Schrauben
{
    public class Class1
    {
        
        public double Datensammlung()
        {
            double[] Steigung = new double[43];
            Steigung[1] = 0.25;
            Steigung[2] = 0.4;
            Steigung[3] = 0.5;
            Steigung[4] = 0.7;
            Steigung[5] = 0.8;
            Steigung[6] = 1;
            Steigung[8] = 1.25;
            Steigung[10] = 1.5;
            Steigung[12] = 1.75;
            Steigung[16] = 2;
            Steigung[20] = 2.5;
            Steigung[24] = 3;
            Steigung[30] = 3.5;
            Steigung[36] = 4;
            Steigung[42] = 4.5;

            return Steigung[Durchmesser];
        }

        public int getDurchmesser()
        {
            Durchmesser = Convert.ToInt32(Console.ReadLine());
            return Durchmesser;
        }

        public int Durchmesser
        { get; set; }

        public double getKerndurch(double x,int y)
        {
            
            double antwort = y -x ;
            return antwort;
        }
    }

}


