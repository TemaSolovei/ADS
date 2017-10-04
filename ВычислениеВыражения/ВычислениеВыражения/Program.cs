using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВычислениеВыражения
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitOrNo = false;

            do
            {
                int number = IO.Input();
                int[] result = Calculate.Results(number);
                exitOrNo = IO.Output(result);
            } while (!exitOrNo);
        }
    }

    class IO
    {
        public static int Input()
        {
            Console.WriteLine("Введите номер элемента (N) последовательности, который необходимо найти");
            int result = CheckInt("Введите число N:");
            return result;
        }

        public static bool Output(int[] result)
        {
            Console.WriteLine();
            Console.WriteLine("Результаты вычислений:");
            Console.WriteLine("Рекурсивный метод: {0}", result[0]);
            Console.WriteLine("Итерационный метод: {0}", result[1]);
            Console.WriteLine("Явный метод: {0}", result[2]);
            Console.WriteLine();

            bool exit = Exit();
            return exit;
        }

        static bool Exit()
        {
            bool checkExit = false;
            ConsoleKeyInfo keyinfo;

            do
            {
                Console.WriteLine("Продолжить работу с программой?");
                Console.WriteLine("Y - Продолжить работу, N - выйти из программы");
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.Y)
                {
                    checkExit = true;
                }
                else if (keyinfo.Key == ConsoleKey.N)
                {
                    checkExit = false;
                }
                else
                {
                    Console.WriteLine("Введите Y или N");
                }
            } while ((keyinfo.Key != ConsoleKey.Y) && (keyinfo.Key != ConsoleKey.N));

            return checkExit;
        }

        static int CheckInt(string message)
        {
            int input; // Введённое число
            bool check = false; // Проверка на введённое число

            do
            {
                Console.Write(message, " ");
                if ((!Int32.TryParse(Console.ReadLine(), out input)) && (input < 0))
                {
                    Console.WriteLine("Пожалуйста, введите целое положительное или равное 0 число!");
                    check = false;
                }
                else check = true;
            } while (!check);

            return input;
        }
    }

    class Calculate
    {
        private static int x0 = 0;
        private static int x1 = -10;

        public static int[] Results(int N)
        {
            int[] results = new int[3]; // Массив с результатами вычисления

            results[0] = Recursive(N);
            results[1] = Iteration(N);
            results[2] = Explicit(N);

            return results;
        }

        static int Recursive(int n)
        {
            if (n == 0) return 0; else
            if (n == 1) return -10; else
            return (-Recursive(n-1)+6*Recursive(n-2)+11*n-17);
        }

        static int Iteration(int n)
        {
            if (n == 0)
            {
                return 0;
            } else if (n == 1)
            {
                return -10;
            } else
            {
                int first = x0;
                int second = x1;
                int result = 0;

                for (int i = 2; i <= n; i++)
                {
                    result = ((-second + 6 * first + 11 * i - 17) / 5); // i-й член последовательности;
                    first = second;
                    second = result;
                }

                return result;
            }            
        }

        static int Explicit(int n)
        {
            double powN = Math.Pow(1.2, n);
            int result = (int)(50-50*powN);

            return result;
        }
    }
}
