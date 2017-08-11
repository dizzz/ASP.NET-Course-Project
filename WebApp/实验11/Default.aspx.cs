using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 实验11
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int value = 0;
            value = Convert.ToInt32(Request["value"]);
            if (!IsPostBack)
            {
                if (value == 1)
                    Label2.Visible = true;
                else
                    Label2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {   //首先检测是否已经人满
                int intUserNum;     // 在线人数
                string strUserName;  // 登陆用户
                string tname;           // 临时用户名
                string users;           // 已在线的用户名
                string[] user;       // 用户在线数组
                intUserNum = int.Parse(Application["userNum"].ToString());
                if (intUserNum >= 20)
                {
                    Response.Write("<script>alert('人数已满，请稍后再登录!')</script>");
                    Response.Redirect("Default.aspx");
                }
                else
                {       // 比较是否有相同的变量
                    Application.Lock();
                    strUserName = (TextBox1.Text).Trim();
                    users = Application["user"].ToString();
                    user = users.Split(',');
                    for (int i = 0; i <= (intUserNum - 1); i++)
                    {
                        tname = user[i].Trim();
                        if (strUserName == tname)
                        {
                            int value = 1;
                            Response.Redirect("Default.aspx?value=" + value);
                        }
                    }
                    // 如果通过验证，则准备登录聊天室
                    if (intUserNum == 0)
                        Application["user"] = strUserName.ToString();
                    else
                        Application["user"] = Application["user"] + "," + strUserName.ToString();
                    intUserNum += 1;
                    object obj = Convert.ToInt32(intUserNum);
                    Application["userNum"] = obj;
                    Session["user"] = strUserName.ToString();
                    Session["isUserChg"] = true;    // 用户列表是否改变
                    Application.UnLock();
                    Response.Redirect("ChatRoom.aspx");
                }
            }
        }
    }
}