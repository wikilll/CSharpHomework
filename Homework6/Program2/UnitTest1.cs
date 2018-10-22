using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program1;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Program2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            OrderDetails orderDetails = new OrderDetails("ww", 1, 1);
            List<OrderDetails> tmp = new List<OrderDetails>();
            tmp.Add(orderDetails);
            Order order = new Order("name", 1, tmp);
            List<Order> tmp2 = new List<Order>();
            tmp2.Add(order);
            OrderService orderService = new OrderService();
            orderService.SetOrders(tmp2);

            OrderService orderService2 = new OrderService();
            orderService2.Add();

            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
            orderService.Export(xmlSer, "1.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("1.xml");

            orderService2.Export(xmlSer, "2.xml");
            XmlDocument xmlDocument2 = new XmlDocument();
            xmlDocument2.Load("2.xml");

            Assert.AreEqual(xmlDocument.InnerXml, xmlDocument2.InnerXml);
        }

        [TestMethod]
        public void RemoveTest()
        {
            OrderService orderService = new OrderService();

            OrderService orderService2 = new OrderService();
            orderService2.Add();
            orderService2.Remove();

            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
            orderService.Export(xmlSer, "1.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("1.xml");

            orderService2.Export(xmlSer, "2.xml");
            XmlDocument xmlDocument2 = new XmlDocument();
            xmlDocument2.Load("2.xml");

            Assert.AreEqual(xmlDocument.InnerXml, xmlDocument2.InnerXml);
        }
        
        [TestMethod]
        public void ShowTest()
        {
            OrderService orderService = new OrderService();
            StreamWriter sw = new StreamWriter("showtest.txt");
            Console.SetOut(sw);
            orderService.Show();
            sw.Flush();
            sw.Close();
            string[] line = File.ReadAllLines("showtest.txt");
            Assert.AreEqual("当前无订单。", line[0]);
        }

        [TestMethod]
        public void ModifyTest()
        {
            OrderDetails orderDetails = new OrderDetails("ww", 1, 1);
            List<OrderDetails> tmp = new List<OrderDetails>();
            tmp.Add(orderDetails);
            Order order = new Order("wiki", 3, tmp);
            List<Order> tmp2 = new List<Order>();
            tmp2.Add(order);
            OrderService orderService = new OrderService();
            orderService.SetOrders(tmp2);

            OrderService orderService2 = new OrderService();
            orderService2.Add();
            orderService2.Modify();

            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
            orderService.Export(xmlSer, "1.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("1.xml");

            orderService2.Export(xmlSer, "2.xml");
            XmlDocument xmlDocument2 = new XmlDocument();
            xmlDocument2.Load("2.xml");

            Assert.AreEqual(xmlDocument.InnerXml, xmlDocument2.InnerXml);
        }

        [TestMethod]
        public void QueryTest()
        {
            OrderService orderService = new OrderService();
            orderService.Add();
            StreamWriter sw = new StreamWriter("querytest2.txt");
            Console.SetOut(sw);
            orderService.Query();
            sw.Flush();
            sw.Close();
            string[] line = File.ReadAllLines("querytest2.txt");
            Assert.AreEqual("未找到此订单!", line[line.Length - 1]);
        }
    }
}
