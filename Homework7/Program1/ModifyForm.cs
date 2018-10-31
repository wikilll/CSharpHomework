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
    public partial class ModifyForm : Form
    {
        public ModifyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            Form1.orderService.Find(num).Clear();
            Form1.orderService.Find(num).CustomerName = textBox5.Text;
            Form1.orderService.Find(num).OrderDetails.Add(new OrderDetails(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            Form1.orderService.Find(num).OrderDetails.Add(new OrderDetails(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
