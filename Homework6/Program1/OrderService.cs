using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Program1
{
    public class OrderService
    {
        public static int num = 0;
        public static int index = 0;
        List<Order> Orders = new List<Order>();
        public List<Order> GetOrders()
        {
            return Orders;
        }
        public void SetOrders(List<Order> orders)
        {
            Orders = orders;
        }

        //添加订单
        public void Add()
        {
            string[] line = File.ReadAllLines("addtest.txt");
            //FileStream fs = new FileStream("addtest.txt", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs, Encoding.Default);

            Order order = new Order();
            Console.WriteLine("请输入客户姓名:");
            order.customerName = line[index++];
            num++;
            order.customerNum = num;

            while (true)
            {
                Console.WriteLine("1、添加商品");
                Console.WriteLine("2、退出添加");
                Console.Write("请选择需要进行的操作:");
                try
                {
                    int option = int.Parse(line[index++]);
                    switch (option)
                    {
                        case 1:
                            order.index2 = index;
                            order.Add();
                            index = order.index2 + 1;
                            break;
                        case 2:
                            Console.WriteLine("成功添加如下订单:");
                            Console.WriteLine("订单号:" + order.customerNum);
                            Console.WriteLine("客户:" + order.customerName);
                            order.Show();
                            Orders.Add(order);
                            order.index2 = 0;
                            index = 0;
                            return;
                        default:
                            Console.WriteLine("请输入1到2之间的数字！任意键继续");
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
        //查找订单
        private Order Find(int i)
        {
            foreach (Order t in Orders)
            {
                if (t.customerNum == i)
                {
                    return t;
                }
            }
            return null;
        }
        //删除订单
        public void Remove()
        {
            string[] line = File.ReadAllLines("removetest.txt");
            try
            {
                Console.WriteLine("请输入要删除的订单号:");
                int i = int.Parse(line[0]);
                if (null == Find(i))
                {
                    Console.WriteLine("未找到此订单！");
                }
                else
                {
                    Orders.Remove(Find(i));
                    Console.WriteLine("删除成功！");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //修改订单
        public void Modify()
        {
            string[] line = File.ReadAllLines("modifytest.txt");
            try
            {
                Console.WriteLine("请输入要修改的订单号:");
                int i = int.Parse(line[index++]);
                if (null == Find(i))
                {
                    Console.WriteLine("未找到此订单！");
                }
                else
                {
                    Console.WriteLine("订单号:" + Find(i).customerNum);
                    Console.WriteLine("客户:" + Find(i).customerName);
                    Find(i).Show();
                    while (true)
                    {
                        Console.WriteLine("1、修改订单");
                        Console.WriteLine("2、放弃修改");
                        Console.Write("请选择需要进行的操作:");
                        int option = int.Parse(line[index++]);
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("请输入新的客户姓名:");
                                Find(i).customerName = line[index++];
                                while (true)
                                {
                                    Console.WriteLine("1、修改商品");
                                    Console.WriteLine("2、放弃修改");
                                    Console.Write("请选择需要进行的操作:");
                                    int option_2 = int.Parse(line[index++]);
                                    switch (option_2)
                                    {
                                        case 1:
                                            Find(i).Clear();
                                            Console.WriteLine("已清除此订单所有商品信息!");
                                            while (true)
                                            {
                                                Console.WriteLine("1、添加商品");
                                                Console.WriteLine("2、修改完毕");
                                                Console.Write("请选择需要进行的操作:");
                                                int option_3 = int.Parse(line[index++]);
                                                switch (option_3)
                                                {
                                                    case 1:
                                                        Find(i).Add();
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("成功修改为如下订单:");
                                                        Console.WriteLine("订单号:" + Find(i).customerNum);
                                                        Console.WriteLine("客户:" + Find(i).customerName);
                                                        Find(i).Show();
                                                        //Orders.Add(Find(i));
                                                        index = 0;
                                                        return;
                                                    default:
                                                        Console.WriteLine("请输入1到2之间的数字！任意键继续");
                                                        Console.ReadKey();
                                                        break;
                                                }

                                            }
                                        case 2:
                                            index = 0;
                                            return;
                                        default:
                                            Console.WriteLine("请输入1到2之间的数字！任意键继续");
                                            Console.ReadKey();
                                            break;
                                    }

                                }
                            case 2:
                                index = 0;
                                return;
                            default:
                                Console.WriteLine("请输入1到2之间的数字！任意键继续");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //显示订单
        public void Show()
        {
            if (0 == Orders.Count)
            {
                Console.WriteLine("当前无订单。");
            }
            else
            {
                foreach (Order t in Orders)
                {
                    Console.WriteLine("订单号:" + t.customerNum);
                    Console.WriteLine("客户:" + t.customerName);
                    t.Show();
                }
            }
        }
        //查询订单
        public void Query()
        {
            string[] line = File.ReadAllLines("querytest.txt");
            Console.WriteLine("查询方式:");
            Console.WriteLine("1、订单号");
            Console.WriteLine("2、商品名");
            Console.WriteLine("3、客户名");
            Console.WriteLine("4、订单金额大于1万元的订单");
            Console.Write("请选择需要进行的操作:");
            try
            {
                int option = int.Parse(line[index++]);
                switch (option)
                {
                    case 1:
                        Console.WriteLine("请输入查询订单的订单号:");
                        int i = int.Parse(line[index++]);
                        var m_1 = from order in Orders where order.customerNum == i select order;
                        if (0 != m_1.Count())
                        {
                            foreach (Order t in m_1)
                            {
                                Console.WriteLine("订单号:" + t.customerNum);
                                Console.WriteLine("客户:" + t.customerName);
                                t.Show();
                            }
                        }
                        else
                            Console.WriteLine("未找到此订单!");
                        break;
                    case 2:
                        Console.WriteLine("请输入查询订单的商品名:");
                        string s1 = line[index++];
                        var m_2 = from order in Orders where order.Find(s1) != null select order;
                        if (0 != m_2.Count())
                        {
                            foreach (Order t in m_2)
                            {
                                Console.WriteLine("订单号:" + t.customerNum);
                                Console.WriteLine("客户:" + t.customerName);
                                t.Show();
                            }
                        }
                        else
                            Console.WriteLine("未找到此订单!");
                        break;
                    case 3:
                        Console.WriteLine("请输入查询订单的客户名:");
                        string s2 = line[index++];
                        var m_3 = from order in Orders where order.customerName.Equals(s2) select order;
                        if (0 != m_3.Count())
                        {
                            foreach (Order t in m_3)
                            {
                                Console.WriteLine("订单号:" + t.customerNum);
                                Console.WriteLine("客户:" + t.customerName);
                                t.Show();
                            }
                        }
                        else
                            Console.WriteLine("未找到此订单!");
                        break;
                    case 4:
                        var m_4 = from order in Orders where order.Sum() > 10000 select order;
                        if (0 != m_4.Count())
                        {
                            foreach (Order t in m_4)
                            {
                                Console.WriteLine("订单号:" + t.customerNum);
                                Console.WriteLine("客户:" + t.customerName);
                                t.Show();
                            }
                        }
                        else
                            Console.WriteLine("未找到此订单!");
                        break;
                    default:
                        Console.WriteLine("请输入1到4之间的数字！任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            index = 0;
        }
        //序列化为xml文件
        public void Export(XmlSerializer xmlSerializer,string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            xmlSerializer.Serialize(fs, Orders);
            fs.Close();
            Console.WriteLine("序列化成功!");
        }
        //从xml文件载入订单
        public void Import(XmlSerializer xmlSerializer, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                Orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
            Console.WriteLine("载入成功!");
        }
    }
}
