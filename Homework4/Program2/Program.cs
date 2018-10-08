using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("欢迎使用订单管理系统！");
            HandleOptions();

        }
        private static void HandleOptions()
        {
            OrderService orderService = new OrderService();
            while (true)
            {
                Console.WriteLine("  菜  单");
                Console.WriteLine("1、添加订单");
                Console.WriteLine("2、删除订单");
                Console.WriteLine("3、修改订单");
                Console.WriteLine("4、查询订单");
                Console.WriteLine("5、显示所有订单");
                Console.WriteLine("6、退出系统");
                Console.Write("请选择需要进行的操作:");
                try
                {
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            orderService.Add();
                            break;
                        case 2:
                            orderService.Remove();
                            break;
                        case 3:
                            orderService.Modify();
                            break;
                        case 4:
                            orderService.Query();
                            break;
                        case 5:
                            orderService.Show();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("请输入1到6之间的数字！任意键继续");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
