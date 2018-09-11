using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            double d1 = Double.Parse(s1);
            double d2 = Double.Parse(s2);
            double pro = d1 * d2;
            string s3 = pro.ToString();
            label1.Text = "The product of " + s1 + " and " + s2 + " is " + s3 + ".";
        }
    }
}
