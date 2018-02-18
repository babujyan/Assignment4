using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Matrix a = new Matrix();
                Matrix b = new Matrix();
                try
                {
                    (a + b).Print();
                }
                catch
                {
                    Console.WriteLine("+");
                }
                int q = 5;
                (q * a).Print();

                try
                {
                    (a * b).Print();
                }
                catch
                {
                    Console.WriteLine("*");
                }
            }
        }
    }
}
