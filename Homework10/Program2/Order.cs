using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class Order
    {
        [Key]
        public string CustomerNum { get; set; }   //订单号
        public string CustomerName { get; set; }  //客户名
        public static int num = 0;
        public List<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            this.CustomerNum = (++num).ToString("000");
            OrderDetails = new List<OrderDetail>();
        }
        public Order(string name)
        {
            this.CustomerName = name;
            this.CustomerNum = (++num).ToString("000");
        }
        public Order(string name,string num, List<OrderDetail> orderDetails)
        {
            this.CustomerName = name;
            this.CustomerNum = num;
            this.OrderDetails = orderDetails;
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
    }
}
