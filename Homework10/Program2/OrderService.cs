using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Program2
{
    public class OrderService
    {
        //public List<Order> Orders = new List<Order>();

        //添加订单
        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                //db.Order.Attach(order);
                //db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        //查找订单
        public Order Find(OrderDB db, string s)
        {

            foreach (Order t in db.Order)
            {
                if (t.CustomerNum == s)
                {
                    return t;
                }
            }
            return null;
        }
        //删除订单
        public void Remove(string orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("Orderdetails").SingleOrDefault(o => o.CustomerNum == orderId);
                db.OrderDetail.RemoveRange(order.OrderDetails);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }
        //更新订单
        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.OrderDetails.ForEach(
                    orderdetail => db.Entry(orderdetail).State = EntityState.Modified);
                db.SaveChanges();
            }
        }
        ////获得订单
        //public Order GetOrder(string orderId)
        //{
        //    using (var db = new OrderDB())
        //    {
        //        return db.Order.Include("Orderdetails").
        //          SingleOrDefault(o => o.CustomerNum == orderId);
        //    }
        //}
        //获得所有订单
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails").ToList<Order>();
            }
        }
        //通过客户名查询订单
        public List<Order> QueryByCustomer(string cusname)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails")
                  .Where(o => o.CustomerName.Equals(cusname)).ToList<Order>();
            }
        }
        //通过商品名查询订单
        public List<Order> QueryByGoods(string comname)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("orderDetails")
                  .Where(o => o.OrderDetails.Where(
                    orderdetail => orderdetail.CommodityName.Equals(comname)).Count() > 0);
                return query.ToList<Order>();
            }
        }
        //通过订单号查询订单
        public List<Order> QueryById(string cusnum)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("orderDetails")
                  .Where(o => o.CustomerNum.Equals(cusnum)).ToList<Order>();
            }
        }

        ////序列化为xml文件
        //public void Export(XmlSerializer xmlSerializer, string fileName)
        //{
        //    FileStream fs = new FileStream(fileName, FileMode.Create);
        //    xmlSerializer.Serialize(fs, Orders);
        //    fs.Close();
        //    Console.WriteLine("序列化成功!");
        //}
        ////从xml文件载入订单
        //public void Import(XmlSerializer xmlSerializer, string fileName)
        //{
        //    using (FileStream fs = new FileStream(fileName, FileMode.Open))
        //    {
        //        Orders = (List<Order>)xmlSerializer.Deserialize(fs);
        //    }
        //    Console.WriteLine("载入成功!");
        //}
    }
}
