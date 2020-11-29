using System;


namespace ConsoleApp1
{
    class Program
    {       
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть першу матрицю через (число і Enter):");
            double[,] matrix1 = new double[3, 3];

            for (int i = 0; i < matrix1.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix1.GetLength(1); ++j)
                {
                    matrix1[i, j] = double.Parse(Console.ReadLine());
                }
            }

            MyMatrix m1 = new MyMatrix(matrix1);
            Console.WriteLine("Перша матриця =>");
            Console.WriteLine(m1);

            Console.WriteLine("Введіть другу матрицю через (число і Enter):");
            double[,] matrix2 = new double[3, 3];

            for (int i = 0; i < matrix2.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix2.GetLength(1); ++j)
                {
                    matrix2[i, j] = double.Parse(Console.ReadLine());
                }
            }

            MyMatrix m2 = new MyMatrix(matrix2);
            Console.WriteLine("Друга матриця =>");
            Console.WriteLine(m2);

            MyMatrix m3 = new MyMatrix(matrix2);

            Console.WriteLine("Додавання двох матриць (першої та другої):");
            m3 = m1 + m2;
            Console.WriteLine(m3);

            Console.WriteLine("Множення двох матриць (першої та другої):");
            m3 = m1 * m2;
            Console.WriteLine(m3);

            Console.WriteLine("Транспонування третьої матриці (результат множення першої та другої):");
            m3.TransponeMe();

            Console.ReadKey();            

        }
    }
}
