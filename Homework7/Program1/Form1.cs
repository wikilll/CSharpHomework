using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            orderService.Orders.Add(new Order("wiki"));
            orderService.Orders[0].OrderDetails.Add(new OrderDetails("ww", 1, 10));
            orderService.Orders[0].OrderDetails.Add(new OrderDetails("www", 2, 300));
            orderService.Orders.Add(new Order("wiiiki"));
            orderService.Orders[1].OrderDetails.Add(new OrderDetails("wi", 1, 10));
            orderService.Orders[1].OrderDetails.Add(new OrderDetails("ki", 2, 300));

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
            string cName = dataGridView1.CurrentCell.Value.ToString();
            foreach (Order t in orderService.Orders)
            {
                if (t.CustomerName.Equals(cName))
                    detailBindingSource.DataSource = t.OrderDetails;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.Orders;
            orderBindingSource.DataSource = orderService.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = orderService.Orders.Where(s => s.CustomerNum == int.Parse(KeyWord1));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            orderBindingSource.DataSource = orderService.Orders.Where(s => s.CustomerName == KeyWord2);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            orderBindingSource.DataSource = orderService.Orders.Where(s => s.Find(KeyWord3) != null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                orderService.Orders.Remove(orderService.Find(int.Parse(dataGridView1.CurrentCell.Value.ToString())));
            }
            catch
            { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyForm modifyForm = new ModifyForm();
            modifyForm.Show();
        }
    }
}
