using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Лабораторная_1
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.Write("введите число\n");
            int n = 0;
            
            do
            {
                try
                {
                   n = Convert.ToInt32(Console.ReadLine());
                   while (n > 1000 || n <= 0)
                   {
                        Console.WriteLine("введите число от нуля до 1000 не включительно!" + "\n");
                        n = Convert.ToInt32(Console.ReadLine());
                   }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Исключение: {ex.Message}" + "\n");
                }

            } while (true);

         
            int Digit = (n + 8) * 10;

            Console.Write("исходное число после мат. операций: " + (int)Digit + "\n");
            Console.Write("Массив случайных чисел: ");


            int[] Massiv = new int[n];
            Random r = new Random();

            for (int i = 0; i < Massiv.Length; ++i)
            {
                Massiv[i] = r.Next(0, 100);
                Console.Write(Massiv[i] + " ");
            }

            Console.ReadKey();
            return 0;
        }
    }
}





