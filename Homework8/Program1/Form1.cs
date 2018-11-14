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
        public OrderService os = new OrderService();
        public string KeyWord1 { get; set; }
        public string KeyWord2 { get; set; }
        public string KeyWord3 { get; set; }

        public Form1()
        {
            InitializeComponent();

            orderService.Orders.Add(new Order("wiki", "001"));
            orderService.Orders[0].OrderDetails.Add(new OrderDetail("ww", 1, 10));
            orderService.Orders[0].OrderDetails.Add(new OrderDetail("www", 2, 300));
            orderService.Orders.Add(new Order("wiiiki", "002"));
            orderService.Orders[1].OrderDetails.Add(new OrderDetail("wi", 1, 10));
            orderService.Orders[1].OrderDetails.Add(new OrderDetail("ki", 2, 300));

            orderBindingSource.DataSource = orderService.Orders;

            textBox1.DataBindings.Add("Text", this, "KeyWord1");
            textBox2.DataBindings.Add("Text", this, "KeyWord2");
            textBox3.DataBindings.Add("Text", this, "KeyWord3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            detailBindingSource.DataSource = ((Order)orderBindingSource.Current).OrderDetails;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.Orders;
            orderBindingSource.DataSource = orderService.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.Orders.Where(s => s.CustomerNum == KeyWord1);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            orderBindingSource.DataSource = orderService.Orders.Where(s => s.CustomerName == KeyWord2);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            orderBindingSource.DataSource = orderService.Orders.Where(s => s.Find(KeyWord3) != null);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //orderService.Orders.Remove(orderService.Find(int.Parse(dataGridView1.CurrentCell.Value.ToString())));
                orderService.Orders.Remove((Order)orderBindingSource.Current);
            }
            catch
            { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyForm modifyForm = new ModifyForm();
            modifyForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = @"..\..\orders.xml";
            orderService.Export(xmlSer, xmlFileName);            

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFileName);

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xslTrans = new XslCompiledTransform();
                xslTrans.Load(@"..\..\orders.xslt");

                FileStream outFileStream = File.OpenWrite(@"..\..\orders.html");
                XmlTextWriter writer = new XmlTextWriter(outFileStream, Encoding.UTF8);
                xslTrans.Transform(nav, null, writer);
            }
            catch
            {
                MessageBox.Show("导出错误！", "Error");
            }
        }
    }
}
