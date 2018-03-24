using System;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы");
            string l = Console.ReadLine();
            if(checkNumber(l))
            {
                Matrix g = new Matrix(Convert.ToInt32(l));
                g.MakeArray();
                g.ShowMatrix();
                Vector v = new Vector(g.arr.GetLength(0));
                v.MakeVector();
                v.ShowVector();

                string res = Multiply(g, v);
                Console.WriteLine("Результат умножения матрицы на вектор {0}", res);
            }
            else
            {
                Console.WriteLine("Размерность матрицы указана в неверном формате");
            }

            Console.ReadLine();
        }

        public static string Multiply(Matrix a, Vector b)
        {
            
            string res;
            int[] c = new int[a.arr.GetLength(0)];
            int sum;
            for (int i = 0; i < a.arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < a.arr.GetLength(0); j++)
                {
                    sum += a.arr[i, j] * b.vec[i];
                }
                c[i] = sum;
            }
            res = String.Join(" ", c);
            File.AppendAllText("output.txt", "Результат умножения массива на вектор: ");
            File.AppendAllText("output.txt", res);
            return res;
        }

        public static bool checkNumber(string l)
        {
            bool isInt;
            int len;
            isInt = Int32.TryParse(l, out len);
            return isInt;
            
        }

    }

    class Matrix
    {
        public int length;

        public int[,] arr;

        public Matrix(int l)
        {
            length = l;
            arr = MakeArray();
        }

        public int[,] MakeArray()
        {
            bool isInt = CheckLength();
            if (isInt)
            {
                int[,] arr = new int[length, length];
                Random ran = new Random();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        arr[i, j] = ran.Next(1, 10);
                    }
                }

                return arr;
            }
            else
            {
                length = 4;
                Console.WriteLine("Размерность массива была задана в неверном формате, поэтому значение размерности взято равным 4");
                int[,] arr = new int[length, length];
                Random ran = new Random();
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        arr[i, j] = ran.Next(1, 10);
                    }
                }
                Console.WriteLine();
                return arr;
            }

        }
        public bool CheckLength()
        {
            try
            {
                length = Convert.ToInt32(length);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Размерность массива задна в неверном формате, {0}", ex.Message);
            }
            if (length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowMatrix()
        {
            Console.WriteLine("Созданная матрица");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Vector
    {
        public int length;
        public int[] vec;

        public Vector(int l)
        {
            length = l;
            vec = MakeVector();
        }

        public int[] MakeVector()
        {
            int[] arr = new int[length];
            Random ran = new Random();

            for (int i = 0; i < length; i++)
            {
                arr[i] = ran.Next(1, 10);
            }
            Console.WriteLine();

            return arr;
        }

        public bool CheckLength()
        {
            try
            {
                length = Convert.ToInt32(length);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Размерность вектора задна в неверном формате, {0}", ex.Message);
            }
            if (length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowVector()
        {
            bool isInt = CheckLength();
            if(isInt)
            {
                Console.WriteLine("Созданный вектор");
                for (int i = 0; i < vec.Length; i++)
                {
                    Console.Write(vec[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Так как размерность вектора задана в некорректном формате, будет взято значение по умолчанию равное 4");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(vec[i] + " ");
                }
            }
        } 
    }   
}