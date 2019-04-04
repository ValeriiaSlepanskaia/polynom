using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomApp
{
    class Polynom
    {
        private List<Part> _polynom = new List<Part>();

        public Polynom(Polynom polynom)
        {
            foreach (var part in polynom._polynom)
            {
                this._polynom.Add(new Part(part));
            }
        }

        public Polynom()
        {
        }

        public Polynom(int[] polynom)
        {
            for (int power = 0; power < polynom.Length; power++)
            {
                int element = polynom[power];
                if (element != 0)
                {
                    Part part = new Part(power, element);
                    this._polynom.Add(part);
                }
            }
        }

        public Polynom Multiply(int number)
        {
            Polynom poly = new Polynom(this);

            foreach (Part element in poly._polynom)
                element.Coef *= number;

            return poly;
        }

        public Polynom Add(int number)
        {
            Polynom poly = new Polynom(this);

            Part part = poly._polynom.Find(x => x.Power == 0);
            if (part == null && number != 0)
            {
                poly._polynom.Add(new Part(0, number));
            }
            else
            {
                part.Coef += number;
            }

            return poly;
        }

        public Polynom Multiply(Polynom multiplier)
        {
            Polynom poly = new Polynom();

            foreach (Part a in multiplier._polynom)
            {
                foreach (Part b in this._polynom)
                {
                    Part mul = new Part(a.Power + b.Power, a.Coef * b.Coef);
                    AddPart(poly._polynom, mul);
                }
            }

            return poly;
        }
       
        public static string MyEquals(Polynom p, Polynom p1)
        {
            string str = "";
            foreach (Part a in p._polynom)
            {
                foreach (Part b in p1._polynom)
                {

                    if (a.Coef == b.Coef && a.Power == b.Power)
                    {
                        str = "равно";

                    }
                    if (a.Coef != (b.Coef)  ||(a.Power != b.Power))

                    {
                        str = "неравно ";
                    }
                } }
            Console.WriteLine(str);

            return str;

        }

        private void AddPart(List<Part> parts, Part add)
        {
            Part part = parts.Find(x => x.Power == add.Power);

            if (part == null && add.Coef != 0)
            {
                parts.Add(add);
            }
            else
            {
                part.Coef += add.Coef;
            }
        }

        public Polynom Add(Polynom polynom2)
        {
            Polynom poly = new Polynom(this);

            foreach (Part part in polynom2._polynom)
            {
                AddPart(poly._polynom, part);
            }

            return poly;
        }

        public Polynom Subtract(Polynom polynom)
        {
            return Add(polynom.Multiply(-1));
        }

        public override string ToString()
        {
            return string.Join("", _polynom.Reverse<Part>()).TrimStart('+');
        }
        public int Calculate(int value)
        {
            int result = 0;

            foreach (Part part in _polynom)
            {
                result += Convert.ToInt32(Math.Pow(value, part.Power) * part.Coef);
            }

            return result;
        }
        public void PrintResult(Polynom sum, Polynom mul, Polynom sub,Polynom sumNum, int calculate)
        {
            Console.Write("Сумма полиномов: ");
            Console.WriteLine(sum.ToString());
            Console.Write("Умножение полиномов: ");
            Console.WriteLine(mul.ToString());
            Console.Write("Разница полиномов: ", sub.ToString());
            Console.WriteLine(sub.ToString());
            Console.Write("Cложение полинома с числом: ", sumNum.ToString());
            Console.WriteLine(sumNum.ToString());
            Console.Write("Расчет значения полинома: ");
            Console.WriteLine(calculate.ToString());
            Console.ReadLine();
        }
        public static Polynom ReadConsole()
        {
            int[] mas = new int[0];
            int n = 0;
            Console.Write("Введите степень полинома: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите коэфициенты полинома: ");
            mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i]=Convert.ToInt32(Console.ReadLine());
            }
            Polynom polynom = new Polynom(mas);
            return polynom;
        }
       

    

        ~Polynom()
        {

        }

    }
}

