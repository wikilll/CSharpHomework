using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Program1
{
    class Program
    {
        private static System.Timers.Timer myTimer;
        public static string sHour, sMinute, sSecond;
        static void Main(string[] args)
        {
            myTimer = new Timer(1000);
            myTimer.AutoReset = true;
            myTimer.Elapsed += new ElapsedEventHandler(OnTimer);
            myTimer.Enabled = true;
            try
            {
                Console.Write("Please input the hour number(0~23) : ");
                sHour = Console.ReadLine();
                Console.Write("Please input the minute number(0~60) : ");
                sMinute = Console.ReadLine();
                Console.Write("Please input the second number(0~60) : ");
                sSecond = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error Input!");
            }
            Console.ReadKey();
        }
        private static void OnTimer(object source,ElapsedEventArgs e)
        {
            if (DateTime.Now.ToLongTimeString().ToString().Equals(sHour + ":" + sMinute + ":" + sSecond))
            {
                Console.WriteLine("Ding Dong~ The time is up !");
                myTimer.Stop();
                return;
            }
        }
    }
}