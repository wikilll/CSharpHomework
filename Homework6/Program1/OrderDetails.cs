using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    public class OrderDetails
    {
        public string commodityName;  //商品名称
        public int commodityNum;   //商品数目
        public int commodityPrice;   //商品单价

        public OrderDetails(string name, int num, int price)
        {
            this.commodityName = name;
            this.commodityNum = num;
            this.commodityPrice = price;
        }
        public OrderDetails() { }
    }
}
