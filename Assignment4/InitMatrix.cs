using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class InitMatrix
    {
        int rows { get; set; }
        int columns { get; set; }

        private readonly double[,] matrix;
        public double this [int i, int j]
        {
            get { return matrix[i , j];}
            private set { matrix[i , j] = value; }
        }

        public InitMatrix()
        {
            bool input = false;
            do
            {
                Console.Write("Rows : ");
                string userInput = Console.ReadLine();
                input = Int32.TryParse(userInput, out int k);
                if (input == true)
                {
                    rows = Int32.Parse(userInput);
                }
                else
                {
                    Console.WriteLine("wrong inpt");
                }
            } while (input == false);

            do
            {
                Console.Write("columns : ");
                string userInput = Console.ReadLine();
                input = Int32.TryParse(userInput, out int k);
                if (input == true)
                {
                    columns = Int32.Parse(userInput);
                }
                else
                {
                    Console.WriteLine("wrong inpt");
                }
            } while (input == false);
            Console.WriteLine("\n" + "rows : " + rows +"\n" + "columns : " + columns +"\n");

            this.matrix = new double[columns , rows];

            for (int n = 0; n < columns; n++)
                for(int m = 0; m < rows; m++)
                {
                    do
                    {
                        Console.Write((n + 1) + "," + (m + 1) + " = ");
                        string userInput = Console.ReadLine();
                        input = Double.TryParse(userInput, out double a);
                        if (input == true)
                        {
                            this.matrix[n, m] = a;//Double.Parse(userInput);
                        }
                        else
                        {
                            Console.WriteLine("wrong inpt");
                            Console.Write(matrix[n, m] + "  ");
                        }
                    } while (input == false);
                }


            Console.Write("\n");
            for (int n = 0; n < columns; n++)
            {
                for (int m = 0; m < rows; m++)
                {
                    Console.Write(matrix[n, m] + "  ");
                }

                Console.Write("\n");
            }


        }
        private InitMatrix(int n , int m)
        {
            this.columns = n;
            this.rows = m;
            this.matrix = new double[columns, rows];            
        }


        public static InitMatrix operator +(InitMatrix m1, InitMatrix m2)
        {
            InitMatrix output = new InitMatrix(m1.columns , m1.rows);
            if (m1.columns == m2.columns && m1.rows == m2.columns)
            {
                for (int i = 0; i < m1.columns; i++)
                {
                    for (int j = 0; j < m1.rows; j++)
                    {
                        output[i, j] = m1[i, j] + m2[i, j];
                    }
                }
            }
            else
            {
                Console.WriteLine("error: Can not add these two matrixs");
            }
            return output;
        }

        public void Print()
        {
            for (int n = 0; n < columns; n++)
            {
                for (int m = 0; m < rows; m++)
                {
                    Console.Write(matrix[n, m] + "  ");
                }
                 
                Console.Write("\n");
            }
        }

        public void F(params int[] ps)
        {
                
        }
    }
}
