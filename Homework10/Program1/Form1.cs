using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using Program2;

namespace Program1
{
    public partial class Form1 : Form
    {
        public static OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();

            //List<OrderDetail> orderDetails1 = new List<OrderDetail>() {
            //    new OrderDetail("a", 1, 10),
            //    new OrderDetail("b", 2, 300)
            //};
            //Order order = new Order("wiki", "234", orderDetails1);
            //orderService.Add(order);

            //List<OrderDetail> orderDetails2 = new List<OrderDetail>() {
            //    new OrderDetail("efw", 13, 100),
            //    new OrderDetail("sfd", 42, 3040)
            //};
            //Order order2 = new Order("wiiiki", "325",orderDetails2);
            ////orderService.Add(order2);
            //orderService.Add(order2);
            orderBindingSource.DataSource = orderService.GetAllOrders();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
            orderBindingSource.DataSource = orderService.GetAllOrders();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            detailBindingSource.DataSource = ((Order)orderBindingSource.Current).OrderDetails;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.GetAllOrders();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                Order order = (Order)orderBindingSource.Current;
                orderService.Remove(order.CustomerNum);
            }
            else
            {
                MessageBox.Show("没有选中订单!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyForm modifyForm = new ModifyForm();
            modifyForm.Show();
            orderBindingSource.DataSource = orderService.GetAllOrders();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
            //string xmlFileName = @"..\..\orders.xml";
            //orderService.Export(xmlSer, xmlFileName);            

            //try
            //{
            //    XmlDocument doc = new XmlDocument();
            //    doc.Load(xmlFileName);

            //    XPathNavigator nav = doc.CreateNavigator();
            //    nav.MoveToRoot();

            //    XslCompiledTransform xslTrans = new XslCompiledTransform();
            //    xslTrans.Load(@"..\..\orders.xslt");

            //    FileStream outFileStream = File.OpenWrite(@"..\..\orders.html");
            //    XmlTextWriter writer = new XmlTextWriter(outFileStream, Encoding.UTF8);
            //    xslTrans.Transform(nav, null, writer);
            //}
            //catch
            //{
            //    MessageBox.Show("导出错误！", "Error");
            //}
        }

        private void QueryOrder()
        {
            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    orderBindingSource.DataSource =
                      orderService.QueryById(textBox1.Text);
                    break;
                case 1:
                    orderBindingSource.DataSource =
                      orderService.QueryByCustomer(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                      orderService.QueryByGoods(textBox1.Text);
                    break;
                default:
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                    break;
            }
            orderBindingSource.ResetBindings(false);
            detailBindingSource.ResetBindings(false);
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            QueryOrder();
        }
    }
}
