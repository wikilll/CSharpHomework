using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
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
            if (textBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("用户名或订单号不可为空！", "输入错误");
            }
            else if ((int.Parse(textBox5.Text)) > 999)
            {
                MessageBox.Show("订单号只能输入三位流水号！", "输入超长");
            }
            else
            {
                try
                {
                    string s = DateTime.Now.ToString("yyyyMMdd") + (int.Parse(textBox5.Text)).ToString("000");
                    Regex rx = new Regex(s);
                    foreach (Order t in Form1.orderService.Orders)
                    {
                        string ss = t.CustomerNum;
                        Match m = rx.Match(ss);
                        if (m.Success)
                        {
                            MessageBox.Show("已有此订单！", "重复输入");
                        }
                    }
                    order.CustomerName = textBox1.Text;
                    order.CustomerNum = s;
                    order.OrderDetails.Add(new OrderDetail(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
                }
                catch
                {
                    MessageBox.Show("订单号格式不正确！", "输入错误");

                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                //textBox5.Text = "";
                textBox5.Text = order.CustomerNum;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order.OrderDetails.Add(new OrderDetail(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.orderService.Orders.Add(order);
        }
    }
}
