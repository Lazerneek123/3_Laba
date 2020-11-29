using System;


namespace ConsoleApp1
{    

    class MyMatrix
    {              
        private double[,] matrix = new double[3, 3];

        public MyMatrix()
        {
            

        }

        public MyMatrix(int i, int j)
        {
            matrix = new double[i, j];

        }

        //1

        public MyMatrix(MyMatrix matrix1)
        {
            matrix = matrix1.matrix;           
        }


        //2

        public MyMatrix(double[,] matrix1)
        {
            matrix = matrix1;
        }


        //3

        public MyMatrix(double[][] matrix1)
        {
            if (matrix1.GetLength(0) != matrix1.GetLength(1))
            {
                throw new Exception("Кількість стовпчиків не дорівнює кількості рядків!");
            }
            else
            {
                for (int i = 0; i < matrix1.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix1.GetLength(1); ++j)
                    {

                        this[i, j] = matrix1[i][j];
                    }

                }
            }

           
        }

        //4

        public MyMatrix(string[] matrix1)
        {
            if (matrix1.GetLength(0) != matrix1.GetLength(1))
            {
                throw new Exception("Кількість стовпчиків не дорівнює кількості рядків!");
            }
            else
            {
                for (int i = 0; i < matrix1.GetLength(0); ++i)
                {
                    string[] matrix2 = matrix1[i].Split(' ');

                    for (int j = 0; j < matrix1.GetLength(1); ++j)
                    {

                        this[i, j] = Convert.ToDouble(matrix2[j]);
                    }

                }
            }
        }

        //5

        public MyMatrix(string matrix1) : this(matrix1.Split('\t'))
        {
            //matrix1 = MyMatrix(matrix1.Split('\t'));
        }

        //6

        public static MyMatrix operator +(MyMatrix matrixA, MyMatrix matrixB)
        {
            if (matrixA.getHeight() != matrixB.getHeight() || matrixA.getWidth() != matrixB.getWidth())
            {
                throw new Exception("Додавання неможливе!");
            }

            MyMatrix matrixC = new MyMatrix();

            for (int i = 0; i < matrixC.getHeight(); ++i)
            {
                for (int j = 0; j < matrixC.getWidth(); ++j)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];

                }
                
            }

            return matrixC;
        }

        //7

        public static MyMatrix operator *(MyMatrix matrixA, MyMatrix matrixB)
        {
            MyMatrix matrixC = new MyMatrix();

            if (matrixA.getHeight() != matrixB.getWidth())
            {
                throw new Exception("Множення неможливе!");
            }
            

            for (int i = 0; i < matrixA.getWidth(); ++i)
            {
                for (int j = 0; j < matrixB.getHeight(); ++j)
                {
                    matrixC[i, j] = 0;

                    for (int k = 0; k < matrixA.getHeight(); ++k)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        //8

        public int Height
        {            
            get { return getHeight(); }
        }

        public int Width
        {
            get { return getWidth(); }
        }


        //9

        public int getHeight()
        {
            return matrix.GetLength(0);
        }


        public int getWidth()
        {
            return matrix.GetLength(1);
        }


        //10

        public double this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }


        //11

        public int[] getCoordinateOfTheMatrix(int i, int j)
        {
            int[] array = { i, j };
            return array;
        }


        public void setCoordinateOfTheMatrix(int i, int j, int n)
        {            
            this[i, j] = n;
        }

        //12

        override public String ToString()
        {
            string s = null;

            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    s += " " + this[i, j] + "\t";
                }
                s += "\n";
            }

            return s;
        }


        //13

        private double[,] GetTransponedArray(double[,] Matrix)
        {            
            double[,] result = new double[Height, Width];

            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    result[j, i] = this[i, j]; // або можна просто result[j, i] = Matrix[i, j] до цьої переданої матриці,
                }                              // або result[j, i] = matrix[i, j]; ну так як нам треба використати індексатор то так.
            }

            return result;
        }


        //14


        public MyMatrix GetTransponedCopy(double[,] Matrix)
        {            
            MyMatrix m = new MyMatrix();
            m.matrix = GetTransponedArray(Matrix);

            return m;
        }


        //15


        public void TransponeMe()
        {
            matrix = GetTransponedArray(matrix);

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write(" {0}", matrix[i, j] + "\t");

                }
                Console.WriteLine();
            }           
 
        }












        /* public int getHeight
         {
             get
             {
                 return matrix.GetLength(0);
             }

         }


         public int getWidth
         {
             get
             {
                 return matrix.GetLength(1);
             }

         }

         public int k(int o, int o1)
         {
             return o;
         }



         //////////////////////////

         public int getName()
         {
             return name;
         }

         public int setName(String name)
         {
             this.name = name;
         }

         //////////////////////////








         // индексатор
         public double this[int i, int j]
          {
              get
              {
                  return matrix[i, j];
              }
              set
              {
                 matrix[i, j] = value;
              }
          }*/



    }
}
