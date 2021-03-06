﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Program2
{
    public class OrderService
    {
        public List<Order> Orders = new List<Order>();
        //添加订单
        public void Add()
        {
            Order order = new Order();
            Console.WriteLine("请输入客户姓名:");
            order.CustomerName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("1、添加商品");
                Console.WriteLine("2、退出添加");
                Console.Write("请选择需要进行的操作:");
                try
                {
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            order.Add();
                            break;
                        case 2:
                            Console.WriteLine("成功添加如下订单:");
                            Console.WriteLine("订单号:" + order.CustomerNum);
                            Console.WriteLine("客户:" + order.CustomerName);
                            order.Show();
                            Orders.Add(order);
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
        public Order Find(string s)
        {
            foreach (Order t in Orders)
            {
                if (t.CustomerNum == s)
                {
                    return t;
                }
            }
            return null;
        }
        //删除订单
        public void Remove()
        {
            try
            {
                Console.WriteLine("请输入要删除的订单号:");
                string s = Console.ReadLine();
                if (null == Find(s))
                {
                    Console.WriteLine("未找到此订单！");
                }
                else
                {
                    Orders.Remove(Find(s));
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
            try
            {
                Console.WriteLine("请输入要修改的订单号:");
                string s = Console.ReadLine();
                if (null == Find(s))
                {
                    Console.WriteLine("未找到此订单！");
                }
                else
                {
                    Console.WriteLine("订单号:" + Find(s).CustomerNum);
                    Console.WriteLine("客户:" + Find(s).CustomerName);
                    Find(s).Show();
                    while (true)
                    {
                        Console.WriteLine("1、修改订单");
                        Console.WriteLine("2、放弃修改");
                        Console.Write("请选择需要进行的操作:");
                        int option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("请输入新的客户姓名:");
                                Find(s).CustomerName = Console.ReadLine();
                                while (true)
                                {
                                    Console.WriteLine("1、修改商品");
                                    Console.WriteLine("2、放弃修改");
                                    Console.Write("请选择需要进行的操作:");
                                    int option_2 = int.Parse(Console.ReadLine());
                                    switch (option_2)
                                    {
                                        case 1:
                                            Find(s).Clear();
                                            Console.WriteLine("已清除此订单所有商品信息!");
                                            while (true)
                                            {
                                                Console.WriteLine("1、添加商品");
                                                Console.WriteLine("2、修改完毕");
                                                Console.Write("请选择需要进行的操作:");
                                                int option_3 = int.Parse(Console.ReadLine());
                                                switch (option_3)
                                                {
                                                    case 1:
                                                        Find(s).Add();
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("成功修改为如下订单:");
                                                        Console.WriteLine("订单号:" + Find(s).CustomerNum);
                                                        Console.WriteLine("客户:" + Find(s).CustomerName);
                                                        Find(s).Show();
                                                        //Orders.Add(Find(i));
                                                        return;
                                                    default:
                                                        Console.WriteLine("请输入1到2之间的数字！任意键继续");
                                                        Console.ReadKey();
                                                        break;
                                                }

                                            }
                                        case 2:
                                            return;
                                        default:
                                            Console.WriteLine("请输入1到2之间的数字！任意键继续");
                                            Console.ReadKey();
                                            break;
                                    }

                                }
                            case 2:
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
                    Console.WriteLine("订单号:" + t.CustomerNum);
                    Console.WriteLine("客户:" + t.CustomerName);
                    t.Show();
                }
            }
        }
        //查询订单
        public void Query()
        {
            Console.WriteLine("查询方式:");
            Console.WriteLine("1、订单号");
            Console.WriteLine("2、商品名");
            Console.WriteLine("3、客户名");
            Console.WriteLine("4、订单金额大于1万元的订单");
            Console.Write("请选择需要进行的操作:");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("请输入查询订单的订单号:");
                        string i = Console.ReadLine();
                        var m_1 = from order in Orders where order.CustomerNum == i select order;
                        if (0 != m_1.Count())
                        {
                            foreach (Order t in m_1)
                            {
                                Console.WriteLine("订单号:" + t.CustomerNum);
                                Console.WriteLine("客户:" + t.CustomerName);
                                t.Show();
                            }
                        }
                        else
                            Console.WriteLine("未找到此订单!");
                        break;
                    case 2:
                        Console.WriteLine("请输入查询订单的商品名:");
                        string s1 = Console.ReadLine();
                        var m_2 = from order in Orders where order.Find(s1) != null select order;
                        if (0 != m_2.Count())
                        {
                            foreach (Order t in m_2)
                            {
                                Console.WriteLine("订单号:" + t.CustomerNum);
                                Console.WriteLine("客户:" + t.CustomerName);
                                t.Show();
                            }
                        }
                        else
                            Console.WriteLine("未找到此订单!");
                        break;
                    case 3:
                        Console.WriteLine("请输入查询订单的客户名:");
                        string s2 = Console.ReadLine();
                        var m_3 = from order in Orders where order.CustomerName.Equals(s2) select order;
                        if (0 != m_3.Count())
                        {
                            foreach (Order t in m_3)
                            {
                                Console.WriteLine("订单号:" + t.CustomerNum);
                                Console.WriteLine("客户:" + t.CustomerName);
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
                                Console.WriteLine("订单号:" + t.CustomerNum);
                                Console.WriteLine("客户:" + t.CustomerName);
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
        }

        //序列化为xml文件
        public void Export(XmlSerializer xmlSerializer, string fileName)
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
