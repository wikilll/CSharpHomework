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
            string s1 = "";
            double d1 = 0;
            Console.Write("Please input a number : ");
            s1 = Console.ReadLine();
            d1 = Double.Parse(s1);
            string s2 = "";
            double d2 = 0;
            Console.Write("Please input a number : ");
            s2 = Console.ReadLine();
            d2 = Double.Parse(s2);
            Console.WriteLine("The product is : " + (d1 * d2));
        }
    }
}
