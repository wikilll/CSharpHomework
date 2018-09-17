using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99];
            for (int i = 0; i < 99; i++)
            {
                a[i] = i + 2;
            }
            for (int j = 2; j <= 100; j++)
            {
                for (int k = 0; k < 99; k++)
                {
                    if (a[k] != 0)
                    {
                        if (a[k] % j == 0 && a[k] / j != 1)
                            a[k] = 0; 
                    }
                }
            }
            Console.WriteLine("Primes between 2 and 100 : ");
            int linesum = 0;
            for (int n = 0; n < 99; n++)
            {
                if (a[n] != 0)
                {
                    Console.Write(a[n] + " ");
                    linesum++;
                    if (linesum % 5 == 0)
                        Console.WriteLine(); 
                }
            }
        }
    }
}
