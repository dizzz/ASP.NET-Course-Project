using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 实验11
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        public void DDLBind()
        {
            ArrayList ItemUserList = new ArrayList();
            string users;           // 已在线的用户名
            string[] user;        // 用户在线数组
            if (Session["user"] != null)
            {
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            int num = int.Parse(Application["userNum"].ToString());
            users = Application["user"].ToString();
            user = users.Split(',');
            ItemUserList.Add("所有人");
            for (int i = (user.Length - 1); i >= 0; i--)
            {
                ItemUserList.Add(user[i].ToString());
            }
            ListBox1.DataSource = ItemUserList;
            ListBox1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string myScript = @"function SelUser() {document.forms[0]['TextBox4'].value = document.forms[0]['ListBox1'].value;}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", myScript, true);
            if (!IsPostBack)
            {
                DDLBind();  //	在下拉列表和左侧的用户列表中加载所有用户名
                ShowChatContent();
                Label1.Text = Session["user"].ToString();
            }
            Label2.Text = Application["userNum"].ToString();
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strTxt = TextBox3.Text.ToString().Replace(",", "，");
            Application.Lock();
            int intChatNum = int.Parse(Application["chatnum"].ToString());
            if (CheckBox1.Checked)
            {   // 处理私聊内容
                if (intChatNum == 0 || intChatNum > 40)
                {
                    intChatNum = 0;
                    Application["chat"] = strTxt.ToString();
                    Application["Owner"] = Session["user"];
                    Application["chattime"] = DateTime.Now;
                    Application["receive"] = TextBox4.Text;
                }
                else
                {
                    Application["chat"] = Application["chat"] + "," + strTxt.ToString();
                    Application["Owner"] = Application["Owner"] + "," + Session["user"];
                    Application["chattime"] = Application["chattime"] + "," + DateTime.Now;
                    Application["receive"] = Application["receive"] + "," + TextBox4.Text;
                }
                intChatNum += 1;
                object obj = intChatNum;
                Application["chatnum"] = obj;
            }
            else
            {   // 处理公共聊天内容
                int intcurrent = int.Parse(Application["current"].ToString());
                if (intcurrent == 0 || intcurrent > 40)
                {
                    intcurrent = 0;
                    Application["chats"] = Session["user"].ToString() + "对" + TextBox4.Text + "说：" + strTxt.ToString() + "(" + DateTime.Now.ToString() + ")";
                }
                else
                {
                    Application["chats"] = Application["chats"].ToString() + "," + Session["user"].ToString() + "对" + TextBox4.Text + "说：" + strTxt.ToString() + "(" + DateTime.Now.ToString() + ")";
                }
                intcurrent += 1;
                object obj = intcurrent;
                Application["current"] = obj;
            }
            Application.UnLock();
            // 刷新聊天内容
            ShowChatContent();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Application.Lock();
            int intUserNum = int.Parse(Application["userNum"].ToString());
            if (intUserNum == 0)
                Application["user"] = "";
            else
            {
                string users;           // 已在线的用户名
                string[] user;      // 用户在线数组
                string OwnerName = Session["user"].ToString();
                users = Application["user"].ToString();
                Application["user"] = "";
                user = users.Split(',');
                for (int i = 0; i <= (user.Length - 1); i++)
                {
                    if (user[i].Trim() != OwnerName.Trim() && user[i].Trim() != "")
                    {
                        Application["user"] = Application["user"] + "," + user[i].ToString();
                    }
                    else
                        intUserNum -= 1;
                }
            }
            object obj = intUserNum;
            Application["userNum"] = obj;
            Application.UnLock();
            Response.Write("<script language=javascript>");
            Response.Write("window.location='Default.aspx';");
            Response.Write("</script>");
        }
        protected void ShowChatContent()
        {
            Application.Lock();
            string OwnerName = Session["user"].ToString();
            {   // 私聊，发送,接收
                TextBox2.Text = "";
                string Owner = Application["Owner"].ToString();
                string[] Ownsers = Owner.Split(',');
                string receive = Application["receive"].ToString();
                string[] receives = receive.Split(',');
                string chat = Application["chat"].ToString();
                string[] chats = chat.Split(',');
                string chattime = Application["chattime"].ToString();
                string[] chattimes = chattime.Split(',');
                for (int i = (Ownsers.Length - 1); i >= 0; i--)
                {
                    if (OwnerName.Trim() == Ownsers[i].Trim())
                    {   // 发送
                        TextBox2.Text = TextBox2.Text + "\n" + "您悄悄地对" + receives[i].ToString() + "说：" + chats[i].ToString() + "(" + chattimes[i].ToString() + ")";
                    }
                    else
                    {
                        if (OwnerName.Trim() == receives[i].Trim())
                        {   // 接收
                            TextBox2.Text = TextBox2.Text + "\n" + Ownsers[i].ToString() + "悄悄地对您说：" + chats[i].ToString() + "(" + chattimes[i].ToString() + ")";
                        }
                    }
                }
                // 公聊
                TextBox1.Text = "";
                int intcurrent = int.Parse(Application["current"].ToString());
                string strchat = Application["chats"].ToString();
                string[] strchats = strchat.Split(',');
                for (int i = (strchats.Length - 1); i >= 0; i--)
                {
                    if (intcurrent == 0)
                    {
                        TextBox1.Text = strchats[i].ToString();
                    }
                    else
                    {
                        TextBox1.Text = TextBox1.Text + "\n" + strchats[i].ToString();
                    }
                }
            }
            Application.UnLock();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DDLBind();          // 在下拉列表和左侧的用户列表中加载所有用户名
            ShowChatContent();
        }
    }

}