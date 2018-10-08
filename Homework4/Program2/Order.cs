using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class Order
    {
        //private int dindex = 0;
        public string customerName;  //客户名
        public int customerNum;   //订单号

        List<OrderDetails> OrderDetails = new List<OrderDetails>();
        public void Add()
        {
            OrderDetails orderDetail = new OrderDetails();
            Console.WriteLine("请输入商品名称:");
            orderDetail.commodityName = Console.ReadLine();
            Console.WriteLine("请输入商品数目:");
            orderDetail.commodityNum = Console.ReadLine();
            Console.WriteLine("请输入商品单价:");
            orderDetail.commodityPrice = Console.ReadLine();
            OrderDetails.Add(orderDetail);
        }
        public void Show()
        {
            Console.WriteLine("商品:");
            foreach (OrderDetails t in OrderDetails)
            {
                Console.WriteLine(t.commodityName + " * " + t.commodityNum + " " + t.commodityPrice + "元/件");
            }
        }
        public void Clear()
        {
            OrderDetails.Clear();
        }
        public Order Find(string s)
        {
            foreach (OrderDetails t in OrderDetails)
            {
                if (t.commodityName.Equals(s))
                {
                    return this;
                }
            }
            return null;
        }
    }
}
