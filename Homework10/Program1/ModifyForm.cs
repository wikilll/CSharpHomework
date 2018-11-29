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
            if (textBox5.Text == "")
            {
                MessageBox.Show("用户名不可为空！", "输入空值错误");
            }
            else
            {
                try
                {

                    using (var db = new OrderDB())
                    {
                        string num = textBox1.Text;
                        string mm = Form1.orderService.Find(db, num).CustomerName;
                        Form1.orderService.Find(db, num).Clear();
                        Form1.orderService.Find(db, num).CustomerName = textBox5.Text;
                        Form1.orderService.Find(db, num).OrderDetails.Add(new OrderDetail(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
                        db.SaveChanges();
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "修改失败");
                }
                textBox5.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new OrderDB())
                {
                    string num = textBox1.Text;
                    Form1.orderService.Find(db, num).OrderDetails.Add(new OrderDetail(textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox4.Text)));
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "输入错误");
            }
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
