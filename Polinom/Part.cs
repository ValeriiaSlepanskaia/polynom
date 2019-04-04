using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PolynomApp
{
    class Part
    {
        private int power;
        private int coef;
        public Part()
        {
        }

        public Part(int power, int coef)
        {
            this.power = power;
            this.coef = coef;
        }

        public Part(Part part) : this(part.Power, part.Coef)
        {
        }

        public int Power
        {
            get { return power; }
            set => power = value;
        }
        public int Coef
        {
            get { return coef; }
            set => coef = value;
        }

        public override string ToString()
        {
            string str;
            if (Coef == 0) return "";
            else if (Power == 0) str = Coef.ToString();
            else str = Coef.ToString() + "x^" + Power.ToString();
            if (Coef >= 0) str = "+" + str;

            return str;
        }

        
            ~Part()
        {
            System.Diagnostics.Trace.WriteLine("First's destructor is called.");

        }
    }
}
