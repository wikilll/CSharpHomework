using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class Order
    {
        public string CustomerName { get; set; }  //客户名
        //public static int num = 0;
        public string CustomerNum { get; set; }   //订单号
        public List<OrderDetail> OrderDetails = new List<OrderDetail>();
        public Order(string name)
        {
            this.CustomerName = name;
            //this.CustomerNum = ++num;          
        }
        public Order(string name,string num)
        {
            this.CustomerName = name;
            this.CustomerNum = DateTime.Now.ToString("yyyyMMdd") + (int.Parse(num)).ToString("000");
            //this.CustomerNum = ++num;          
        }
        public Order()
        {
            //this.CustomerNum = ++num;
        }
        //添加商品（订单明细）
        public void Add()
        {
            try
            {
                OrderDetail orderDetail = new OrderDetail();
                Console.WriteLine("请输入商品名称:");
                orderDetail.CommodityName = Console.ReadLine();
                Console.WriteLine("请输入商品数目:");
                orderDetail.CommodityNum = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入商品单价:");
                orderDetail.CommodityPrice = int.Parse(Console.ReadLine());
                OrderDetails.Add(orderDetail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //显示订单明细
        public void Show()
        {
            Console.WriteLine("商品:");
            foreach (OrderDetail t in OrderDetails)
            {
                Console.WriteLine(t.CommodityName + " * " + t.CommodityNum + " " + t.CommodityPrice + "元/件");
            }
        }
        //清空订单明细
        public void Clear()
        {
            OrderDetails.Clear();
        }
        //查找订单明细
        public Order Find(string s)
        {
            foreach (OrderDetail t in OrderDetails)
            {
                if (t.CommodityName.Equals(s))
                {
                    return this;
                }
            }
            return null;
        }
        //计算订单金额
        public int Sum()
        {
            int sum = 0;
            foreach (OrderDetail t in OrderDetails)
            {
                sum += t.CommodityPrice * t.CommodityNum;
            }
            return sum;
        }
    }
}
