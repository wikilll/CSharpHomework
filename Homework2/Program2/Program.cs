using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        //最小值
        public static int Min(int[] array)
        {
            if (array == null) throw new Exception("Null Error!");
            int val = 0;
            bool hasValue = false;
            foreach (int x in array)
            {
                if (hasValue)
                {
                    if (x < val)
                        val = x;
                }
                else
                {
                    val = x;
                    hasValue = true;
                }
            }
            if (hasValue) return val;
            throw new Exception("Not Found!");
        }
        //最大值
        public static int Max(int[] array)
        {
            if (array == null) throw new Exception("Null Error!");
            int val = 0;
            bool hasValue = false;
            foreach (int x in array)
            {
                if (hasValue)
                {
                    if (x > val)
                        val = x;
                }
                else
                {
                    val = x;
                    hasValue = true;
                }
            }
            if (hasValue) return val;
            throw new Exception("Not Found!");
        }
        //平均值
        public static double Average(int[] array)
        {
            if (array == null) throw new Exception("数组空异常");
            long sum = 0;
            long count = 0;
            foreach (int v in array)
            {
                if (v != 0)
                {
                    sum += v;
                    count++;
                }
            }
            if (count > 0) return (double)sum / count;
            return 0;
        }
        //求和
        public static long Sum(int[] array)
        {
            if (array == null) throw new Exception("Null Error!");
            long sum = 0;
            foreach (int v in array)
            {
                if (v != 0)
                {
                    sum += v;
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 1, 88, 62, 7, 0, -24, 49, 555, 991, 423 };
            int min = Min(myArray);
            int max = Max(myArray);
            double average = Average(myArray);
            long sum = Sum(myArray);
            Console.WriteLine("Min : " + min);
            Console.WriteLine("Max : " + max);
            Console.WriteLine("Average : " + average);
            Console.WriteLine("Sum : " + sum);
        }
    }
}