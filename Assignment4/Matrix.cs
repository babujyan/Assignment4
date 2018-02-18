using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    /// <summary>
    /// New typ for Matrixs (2d arrays) 
    /// </summary>
    class Matrix
    {
        /// <summary>
        /// Numbr of Rows in matrix.
        /// </summary>
        int rows { get; set; }

        /// <summary>
        /// Number of Columns.
        /// </summary>
        int columns { get; set; }

        /// <summary>
        /// Field for matrix
        /// </summary>
        private double[,] matrix;

        /// <summary>
        /// Propertes for matrix
        /// </summary>
        /// <param name="i">Rows</param>
        /// <param name="j">Columns</param>
        /// <returns></returns>
        public double this[int i, int j]
            {
                get { return matrix[i, j]; }
                private set { matrix[i, j] = value; }
            }

        /// <summary>
        /// Init matrix
        /// </summary>
        public Matrix()
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
            Console.WriteLine("\n" + "rows : " + rows + "\n" + "columns : " + columns + "\n");

            this.matrix = new double[columns, rows];

            for (int n = 0; n < rows; n++)
                for (int m = 0; m < columns; m++)
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

        /// <summary>
        /// Init empty Matrix
        /// </summary>
        /// <param name="n">Rows</param>
        /// <param name="m">Columns</param>
        private Matrix(int n, int m)
        {
            this.columns = n;
            this.rows = m;
            this.matrix = new double[columns, rows];
        }

        /// <summary>
        /// "+" operator for Matrixs.
        /// </summary>
        /// <param name="m1">First matrix.</param>
        /// <param name="m2">Seond matrix.</param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix output = new Matrix(m1.columns, m1.rows);
            if (m1.columns == m2.columns && m1.rows == m2.rows)
            {
                for (int i = 0; i < m1.columns; i++)
                {
                    for (int j = 0; j < m1.rows; j++)
                    {
                        output[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException("Matrixes should be the same size, "+" operator can not be operted");
            }
        }

        /// <summary>
        /// "-" operator for Matrixs.
        /// </summary>
        /// <param name="m1">First matrix.</param>
        /// <param name="m2">Seond matrix.</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix output = new Matrix(m1.columns, m1.rows);

            if (m1.columns == m2.columns && m1.rows == m2.rows)
            {
                for (int i = 0; i < m1.columns; i++)
                {
                    for (int j = 0; j < m1.rows; j++)
                    {
                        output[i, j] = m1[i, j] - m2[i, j];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException("Matrixes should be the same size, " + " operator can not be operted");
            }
        }

        /// <summary>
        /// "*" operator for Scalar multiplication.
        /// </summary>
        /// <param name="d">Scalr</param>
        /// <param name="m">Matrix</param>
        /// <returns></returns>
        public static Matrix operator *(double d,  Matrix m)
        {
            Matrix output = new Matrix(m.columns, m.rows);
            for (int i = 0; i < m.columns; i++)
                {
                    for (int j = 0; j < m.rows; j++)
                    {
                        output[i, j] = d * m[i, j];
                    }
                }
            return output;
        }

        /// <summary>
        /// "*" operator for Matrixs.
        /// </summary>
        /// <param name="m1">First matrix.</param>
        /// <param name="m2">Seond matrix.</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix output = new Matrix(m1.columns, m1.rows);
            if (m1.columns == m2.rows)
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
                    {
                        for(int k = 0; k < m1.rows; k++)
                        {
                            output[i, j] += m1[i, k] + m2[k, j];
                        }
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException(" Column of first matrix not equal to row of second.");
            }
        }

        /// <summary>
        /// Transpose matrix.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Matrix operator ^(Matrix m , string t)
        {
            Matrix output = new Matrix(m.columns, m.rows);
            if (t == "T" || t =="t")
            {
                for (int i = 0; i < m.rows; i++)
                {
                    for (int j = 0; j < m.columns; j++)
                    {
                        output[j, i] = m[i, j];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException("Error");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Matrix operator ^(Matrix m, int t)
        {
            // not done yet 
            Matrix output = new Matrix(m.columns, m.rows);
            if (t == -1)
            {
                for (int i = 0; i < m.rows; i++)
                {
                    for (int j = 0; j < m.columns; j++)
                    {
                        output[j, i] = m[i, j];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException("Error");
            }
        }

        /// <summary>
        /// Retrurns the smallest element from the matrix.
        /// </summary>
        /// <returns></returns>
        public double Min()
        {
            double min = this.matrix[1, 1];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (min > this.matrix[i,j])
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }

        /// <summary>
        /// Returns the largest element of the matrix.
        /// </summary>
        /// <returns></returns>
        public double Max()
        {
            double max = this.matrix[1, 1];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (max < this.matrix[i, j])
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// Prints the matrix.
        /// </summary>
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
    }

}

