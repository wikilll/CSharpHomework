using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    [Serializable]
    public class Order
    {
        public string customerName;  //客户名
        public int customerNum;   //订单号

        public List<OrderDetails> OrderDetails = new List<OrderDetails>();
        //添加商品（订单明细）
        public void Add()
        {
            try
            {
                OrderDetails orderDetail = new OrderDetails();
                Console.WriteLine("请输入商品名称:");
                orderDetail.commodityName = Console.ReadLine();
                Console.WriteLine("请输入商品数目:");
                orderDetail.commodityNum = int.Parse(Console.ReadLine());
                Console.WriteLine("请输入商品单价:");
                orderDetail.commodityPrice = int.Parse(Console.ReadLine());
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
            foreach (OrderDetails t in OrderDetails)
            {
                Console.WriteLine(t.commodityName + " * " + t.commodityNum + " " + t.commodityPrice + "元/件");
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
            foreach (OrderDetails t in OrderDetails)
            {
                if (t.commodityName.Equals(s))
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
            foreach (OrderDetails t in OrderDetails)
            {
                sum += t.commodityPrice * t.commodityNum;
            }
            return sum;
        }
    }
}
