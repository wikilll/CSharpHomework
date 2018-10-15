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
        double k, th1, th2, per1, per2;
        float width;
        string color_1;
        public Form1()
        {
            InitializeComponent();
        }
        //获取随机数据
        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            color_1 = ColorTranslator.ToHtml(Color.FromArgb(r.Next(0, 255),r.Next(0, 255),r.Next(0, 255)));
            k = r.Next(15, 100) * 0.01;
            th1 = r.Next(1000, 5000) * 0.01 * Math.PI / 180;
            th2 = r.Next(1000, 5000) * 0.01 * Math.PI / 180;
            per1 = r.Next(20, 75) * 0.01;
            per2 = r.Next(20, 75) * 0.01;
            width = (float)(r.Next(0, 2000) * 0.001);
            textBox3.Text = k.ToString();
            textBox1.Text = (th1 / Math.PI * 180).ToString();
            textBox2.Text = (th2 / Math.PI * 180).ToString();
            textBox4.Text = per1.ToString();
            textBox5.Text = per2.ToString();
            textBox7.Text = width.ToString();
            textBox6.Text = color_1;
        }
        //画图
        private void button1_Click(object sender, EventArgs e)
        {
            k = double.Parse(textBox3.Text);
            th1 = double.Parse(textBox1.Text) * Math.PI / 180;
            th2 = double.Parse(textBox2.Text) * Math.PI / 180;
            per1 = double.Parse(textBox4.Text);
            per2 = double.Parse(textBox5.Text);
            width = float.Parse(textBox7.Text);
            color_1 = textBox6.Text;

            if (graphics == null) graphics = this.CreateGraphics();
            DrawCayleyTree(10, 400, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;

        void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            double x2 = x0 + leng * Math.Cos(th) * k;
            double y2 = y0 + leng * Math.Sin(th) * k;

            DrawLine(x0, y0, x1, y1);
            DrawLine(x0, y0, x2, y2);

            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }

        void DrawLine(double x0, double y0, double x1, double y1)
        {
            Color color = ColorTranslator.FromHtml(color_1);
            Pen pen = new Pen(color,width);

            graphics.DrawLine(
                pen,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}
