using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("用户名或订单号不可为空！", "输入空值错误");
            }
            else if((int.Parse(textBox6.Text))>999)
            {
                MessageBox.Show("订单号只能输入三位流水号！", "输入超长");
            }
            else
            {
                try
                {
                    string s = DateTime.Now.ToString("yyyyMMdd") + (int.Parse(textBox6.Text)).ToString("000");
                    Regex rx = new Regex(s);
                    foreach (Order t in Form1.orderService.Orders)
                    {
                        string ss = t.CustomerNum;
                        Match m = rx.Match(ss);
                        if (m.Success)
                        {
                            MessageBox.Show("已有此订单！", "重复输入订单号");
                        }
                    }

                    string num = textBox1.Text;

                    string mm = Form1.orderService.Find(num).CustomerName;

                    Form1.orderService.Find(num).Clear();
                    Form1.orderService.Find(num).CustomerName = textBox5.Text;
                    Form1.orderService.Find(num).CustomerNum = s;
                    Form1.orderService.Find(s).OrderDetails.Add(new OrderDetail(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
                    textBox1.Text = s;
                }
                catch
                {
                    MessageBox.Show("订单号格式不正确！", "输入错误");
                }
                textBox5.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;
            Form1.orderService.Find(num).OrderDetails.Add(new OrderDetail(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
        }
    }
}
