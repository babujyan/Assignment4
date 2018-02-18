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

            InitMatrix a = new InitMatrix();
            InitMatrix b = new InitMatrix();
            (a + b).Print();
        }
    }
}
