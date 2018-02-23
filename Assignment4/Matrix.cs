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
        /// Number ofRows in matrix.
        /// </summary>
        int rows { get; set; }

        /// <summary>
        /// Number of Columns.
        /// </summary>
        int columns { get; set; }

        /// <summary>
        /// Input data by user.
        /// </summary>
        string userInput;

        /// <summary>
        /// Field for matrix (2D double array)
        /// </summary>
        private double[,] matrix;

        /// <summary>
        /// The indexer method for matrix.
        /// </summary>
        /// <param name="rows">Rows</param>
        /// <param name="columns">Columns</param>
        /// <returns></returns>
        public double this[int rows, int columns]
        {
            get { return this.matrix[rows, columns]; }
            private set { this.matrix[rows, columns] = value; }
        }
        
        /// <summary>
        /// Init matrix randomly or by user input.
        /// </summary>
        public Matrix()
        {
            // Does user input in a proper format or not. Init value is false.
            bool input = false;
            
            //Input Rows.
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

            //Input Columns.
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

            //Console.WriteLine("\n" + "rows : " + rows + "\n" + "columns : " + columns + "\n");

            //Init 2D array for Matrix.
            this.matrix = new double[rows, columns];

            // Does user input in a proper format or not. Init value is false.
            input = false;

            //Fill matrix randomly or by user Input.
            do
            {
                Console.Write("randomly or by user ? ");
                userInput = Console.ReadLine();

                if (userInput != "randomly" && userInput != "by user")
                {
                    Console.WriteLine("wrong inpt");
                }

                //User input is true.
                else
                    input = true;

            } while (input == false);

            //If matrix should be filled by user.
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
            //Matrix should be filled by user.
            else
            {
                Random random = new Random();
                for (int n = 0; n < rows; n++)
                {
                    for (int m = 0; m < columns; m++)
                    {
                        matrix[n,m] = random.Next();
                    }
                }
            }
        }

        /// <summary>
        /// Init empty Matrix
        /// </summary>
        /// <param name="rows">number of rows in matrix.</param>
        /// <param name="columns">Number of columns in matrix.</param>
        private Matrix(int rows, int columns)
        {
            this.columns = columns;
            this.rows = rows;
            this.matrix = new double[this.rows , this.columns];
        }

        /// <summary>
        /// "+" operator for Matrixs.
        /// </summary>
        /// <param name="m1">First matrix.</param>
        /// <param name="m2">Seond matrix.</param>
        /// <returns></returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix output = new Matrix(m1.rows, m1.columns);

            if (m1.columns == m2.columns && m1.rows == m2.rows)
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m1.columns; j++)
                    {
                        output[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException("Matrices should be the same size, + operator can not be operated");
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
            Matrix output = new Matrix(m1.rows, m1.columns);

            if (m1.columns == m2.columns && m1.rows == m2.rows)
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m1.columns; j++)
                    {
                        output[i, j] = m1[i, j] - m2[i, j];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException("Matrixes should be the same size, - operator can not be operted");
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
            Matrix output = new Matrix(m.rows , m.columns);
            for (int i = 0; i < m.columns; i++)
                {
                    for (int j = 0; j < m.rows; j++)
                    {
                        output[j,i] = d * m[j,i];
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
            Matrix output = new Matrix(m1.rows , m2.columns);
            if (m1.columns == m2.rows)
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
                    {
                        for(int k = 0; k < m2.rows; k++)
                        {
                            output[i, j] += m1[i, k] * m2[k, j];
                        }
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException(" The column of first matrix not equal to the row of second matrix.");
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
            Matrix output = new Matrix(this.rows , this.columns);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    output[i,j] = this[j,i];
                }
            }
            return output;
        }

        /// <summary>
        /// Invers matrix using Gauss–Jordan elimination.  
        /// </summary>
        /// <returns>Inversed matrix</returns>
        public Matrix Inverse()
        {
            if (this.rows == this.columns)
            {
                int rows = this.rows;
                int columns = this.columns;
                Matrix temporary = new Matrix(rows , this.columns);

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
                                    double tempr = matrix[k, w];
                                    matrix[k, w] = matrix[i, w];
                                    matrix[i, w] = tempr;
                                }
                                for (int w = 0; w < columns; w++)
                                {
                                    double tempr = temporary[k, w];
                                    temporary[k, w] = temporary[i, w];
                                    temporary[i, w] = tempr;
                                }
                                inversible = true;
                                break;
                            }
                        }
                        if (!inversible)
                        {
                            throw new Exception("Matrix does not have invers");
                        }
                    }

                    double temp = matrix[i, i];
                    for (int j = 0; j < columns; j++)
                    {
                        temporary[i, j] = temporary[i, j] / temp;
                        matrix[i, j] = matrix[i, j] / temp;
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
                throw new Exception("Matrix should be square (rows = coulms)");

        }

        /// <summary>
        /// Translat the object.
        /// </summary>
        /// <param name="ps">Array for Tanslation n dimantional ojects.</param>
        /// <returns>Translated matrix.</returns>
        public Matrix Translate(params double[] ps)
        {

            if(this.rows == ps.Length)
            {
                Matrix matrix = this.Copy();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] += ps[i];
                    }
                }
                return matrix;
            }
            else
            {
                throw new Exception("You can not trnslate matrix with these parametrs.");
            }
        }

        /// <summary>
        /// Scale the matrix.
        /// </summary>
        /// <param name="s">Scaling factors.</param>
        /// <returns>Sclaed matrix.</returns>
        public Matrix Scale(params double[] s )
        {
            if (this.rows == s.Length)
            {
                Matrix scale = new Matrix(this.rows, this.rows);

                for(int i=0; i < scale.rows; i++)
                {
                    scale[i, i] = s[i];
                }

                Matrix matrix = scale * this;
                return matrix;
            }
            else
            {
                throw new Exception("You can not scale this matrix with these factors");
            }
        }

        /// <summary>
        /// Rotate matrix. Only for 2D
        /// </summary>
        /// <param name="angle">Angle of rotation.</param>
        /// <returns>Rotated matrix.</returns>
        public Matrix Rotate(double angle)
        {
            if (this.rows == this.columns && this.columns == 2)
            {
                Matrix r = new Matrix(2, 2);
                r[0, 0] = Math.Cos(angle);
                r[0, 1] = -Math.Sin(angle);
                r[1, 0] = Math.Sin(angle);
                r[1, 1] = Math.Cos(angle);

                return r * this;
            }
            else
            {
                throw new Exception("You should use only 2D matrices(rows=2)");
            }
        }

        /// <summary>
        /// Finds the smallest element from the matrix.
        /// </summary>
        /// <returns>Smallest element from the matrix.</returns>
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
        /// Finds the largest element of the matrix.
        /// </summary>
        /// <returns>Largest element of the matrix.</returns>
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
                for (int n = 0; n < rows; n++)
                {
                    for (int m = 0; m < columns; m++)
                    {
                        Console.Write(matrix[n,m] + "  ");
                    }

                    Console.Write("\n");
                }
            }

        /// <summary>
        /// Copy the matrix.
        /// </summary>
        /// <returns>Copy of the matrix</returns>
        public Matrix Copy()
        {
            Matrix matrix = new Matrix(this.rows, this.columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = this.matrix[i, j];
                }
            }

            return matrix;
        }

       /// <summary>
       /// Ceckes is the matrix ortogonal or not.
       /// </summary>
       /// <returns>Ortogonal or not.</returns>
        public bool IsOrtogonal()
        {
            Matrix matrix = this * this.Transpose();

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