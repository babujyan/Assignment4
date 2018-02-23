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

        string userInput;

        /// <summary>
        /// Field for matrix
        /// </summary>
        private double[,] matrix;

        /// <summary>
        /// The indexer method.
        /// </summary>
        /// <param name="i">Rows</param>
        /// <param name="j">Columns</param>
        /// <returns></returns>
        public double this[int i, int j]
            {
                get { return this.matrix[i, j]; }
                private set { this.matrix[i, j] = value; }
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
                userInput = Console.ReadLine();
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
                userInput = Console.ReadLine();
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
            input = false;
            do
            {
                Console.Write("randomly or by user ? ");
                userInput = Console.ReadLine();

                if (userInput != "randomly" && userInput != "by user")
                {
                    Console.WriteLine("wrong inpt");
                }

                else input = true;

            } while (input == false);

            if (userInput == "by user")
            {
                for (int n = 0; n < rows; n++)
                {
                    for (int m = 0; m < columns; m++)
                    {
                        do
                        {
                            Console.Write((n + 1) + "," + (m + 1) + " = ");
                            userInput = Console.ReadLine();
                            input = Double.TryParse(userInput, out double a);
                            if (input == true)
                            {
                                this.matrix[n, m] = Double.Parse(userInput);
                            }
                            else
                            {
                                Console.WriteLine("wrong inpt");
                                Console.Write(matrix[n, m] + "  ");
                            }
                        } while (input == false);
                    }
                }
            }
            else
            {
                Random random = new Random();
                for (int n = 0; n < columns; n++)
                {
                    for (int m = 0; m < rows; m++)
                    {
                        matrix[n, m] = random.Next();
                    }
                }
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
            Matrix output = new Matrix(m2.columns, m1.rows);
            if (m1.columns == m2.rows)
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
                    {
                        for(int k = 0; k < m2.rows; k++)
                        {
                            output[j, i] += m1[k,i] * m2[j,k];
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
        public Matrix Transpose()
        {
            Matrix output = new Matrix(this.columns, this.rows);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    output[j, i] = this[i, j];
                }
            }
            return output;
        }

        /// <summary>
        /// Invers matrix
        /// </summary>
        /// <returns>Inversed matrix</returns>
        public Matrix Inverse()
        {
            if (this.rows == this.columns)
            {
                int rows = this.rows;
                int columns = this.columns;
                Matrix temporary = new Matrix(columns, rows);

                Matrix matrix = this.Copy();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == j)
                        {
                            temporary[i, j] = 1;
                        }
                        else
                        {
                            temporary[i, j] = 0;
                        }
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, i] == 0)
                    {
                        bool inversible = false;
                        for (int k = i + 1; k < rows; k++)
                        {
                            if (matrix[k, i] != 0)
                            {
                                for (int w = i; w < columns; w++)
                                {
                                    double tempr = matrix[w, k];
                                    matrix[w, k] = matrix[w, i];
                                    matrix[w, i] = tempr;
                                }
                                for (int w = 0; w < columns; w++)
                                {
                                    double tempr = temporary[w, k];
                                    temporary[w, k] = temporary[w, i];
                                    temporary[w, i] = tempr;
                                }
                                inversible = true;
                                break;
                            }
                        }
                        if (!inversible)
                        {
                            throw new Exception("Error");
                        }
                    }
                    for (int j = 0; j < columns; j++)
                    {
                        temporary[i, j] = temporary[i, j] / matrix[i, i];
                        matrix[i, j] = matrix[i, j] / matrix[i, i];
                    }
                    for (int k = 0; k < rows; k++)
                    {
                        if (k != i && matrix[k, i] != 0)
                        {
                            for (int j = i; j < columns; j++)
                            {
                                temporary[k, j] -= matrix[k, i] * temporary[i, j];
                                matrix[k, j] -= matrix[k, i] * matrix[i, j];

                            }
                        }
                    }
                }

            return temporary;
            }

            else
                throw new Exception("Error");

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

        public Matrix Copy()
        {
            Matrix matrix = new Matrix(this.columns, this.rows);

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i, j] = this.matrix[i, j];
                }
            }

            return matrix;
        }

       
        public bool IsOrtogonal()
        {
            Matrix matrix = this * (this ^ "t");

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    if (i == j)
                    {
                        if(matrix[i , j] != 1 )
                        {
                            return false;
                        }
                    }
                    else if(matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}