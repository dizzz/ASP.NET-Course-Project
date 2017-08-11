using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 实验10
{
    public partial class Calculator : System.Web.UI.Page
    {
        public static double temp1;         // 存储第一个变量
        public static double temp2;     // 存储第二个变量
        public static int m;            // 保存输入的状态
        public bool dot = false;        // 判断是否点击“=”号

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "1"; }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "2"; }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "3"; }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "4"; }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "5"; }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "6"; }
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "7"; }
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "8"; }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "9"; }
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            if (dot != true)
            { this.TextBox1.Text += "0"; }
        }
        protected void Button11_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                temp1 = Convert.ToInt32(this.TextBox1.Text);
                this.TextBox1.Text = "";
                m = 0;
            }
        }
        protected void Button12_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                temp1 = Convert.ToInt32(this.TextBox1.Text);
                this.TextBox1.Text = "";
                m = 1;
            }
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                temp1 = Convert.ToInt32(this.TextBox1.Text);
                this.TextBox1.Text = "";
                m = 2;
            }
        }
        protected void Button15_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text != "")
            {
                temp1 = Convert.ToInt32(this.TextBox1.Text);
                this.TextBox1.Text = "";
                m = 3;
            }
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            dot = false;
            this.TextBox1.Text = "";
            temp1 = 0.0;
            temp2 = 0.0;
        }
        protected void Button16_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text == "" && temp1 != null)
            {
                this.TextBox1.Text = temp1.ToString();
                dot = true;
            }
            else
            {
                double temp3 = 0.0;
                temp2 = Convert.ToDouble(this.TextBox1.Text);
                localhost.Service result = new localhost.Service();
                switch (m)
                {
                    case 0:
                        temp3 = result.Sum(temp1, temp2);
                        break;
                    case 1:
                        temp3 = result.Sub(temp1, temp2);
                        break;
                    case 2:
                        temp3 = result.Mult(temp1, temp2);
                        break;
                    case 3:
                        temp3 = result.Div(temp1, temp2);
                        break;
                    default:
                        Response.Write("数据有误，请重新输入！");
                        break;
                }
                if (temp3 > double.MaxValue)
                {
                    Response.Write("<script>alert('结果值超出双精度最大值！')</script>");
                    return;
                }
                this.TextBox1.Text = temp3.ToString();
                dot = true;
            }
        }
    }

}