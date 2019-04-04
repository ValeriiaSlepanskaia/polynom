using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //int[] a = { -3, 7, 2 }; // 2x^2 + 7x - 3
            //int[] b = { 9, 7, 0, 4 }; // 4x^3 + 7x + 9
            Polynom first =  Polynom.ReadConsole();
            Polynom second =  Polynom.ReadConsole();
            string s = Polynom.MyEquals(first, second);

            int x = 2;
            Polynom sum = first.Add(second); // 4x^3 + 2x^2 + 14x + 6
            Polynom mul = first.Multiply(second); // 8 x^5 + 28 x^4 + 2 x^3 + 67 x^2 + 42 x - 27
            Polynom sub = first.Subtract(second); // -4 x^3 + 2 x^2 - 12
            Polynom sumNum = first.Add(x); // -4 x^3 + 2 x^2 - 12
            int calculate = first.Calculate(x);

            first.PrintResult(sum,mul,sub,sumNum,calculate);

            ;
        }
    }
}
