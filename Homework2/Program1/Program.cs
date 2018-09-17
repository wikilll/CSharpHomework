using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input an int : ");
            string s = Console.ReadLine();
            int n = Int32.Parse(s);
            Console.Write("Prime factors of the number : ");
            for(int i = 2; i <= n; i++)
            {
                int Flag = 0;
                if (n % i != 0) continue;
                for(int j = 2;j < i;j++)
                {
                    if (i % j == 0)
                    {
                        Flag = 1;
                        break;
                    }
                }
                if(Flag == 0)
                Console.Write(i + " ");
            }
        }
    }
}
