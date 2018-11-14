using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class OrderDetail
    {
        public string CommodityName { get; set; }  //商品名称
        public int CommodityNum { get; set; }    //商品数目
        public int CommodityPrice { get; set; }    //商品单价

        public OrderDetail(string name, int num, int price)
        {
            this.CommodityName = name;
            this.CommodityNum = num;
            this.CommodityPrice = price;
        }
        public OrderDetail() { }
    }
}
