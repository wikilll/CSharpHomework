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
    public partial class AddForm : Form
    {
        public Order order = new Order();
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.CustomerName = textBox1.Text;
            order.OrderDetails.Add(new OrderDetails(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order.OrderDetails.Add(new OrderDetails(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.orderService.Orders.Add(order);
        }
    }
}
