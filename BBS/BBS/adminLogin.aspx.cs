using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp {
    public partial class adminLogin : System.Web.UI.Page {
        protected void ButtonLogin_Click(object sender, EventArgs e) {   //获取用户在页面上的输入
            string userLoginName = TextBoxLoginName.Text.Trim();        // 用户登录名
            string userPassword = TextBoxPassword.Text.Trim();          // 密码
            SqlDataReader dr;  
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();   // 新建Command对象
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM [adminUser] where LoginName=@LoginName";
            cmd.CommandType = CommandType.Text;
            // 添加查询参数对象,并给参数赋值
            SqlParameter para = new SqlParameter("@LoginName", SqlDbType.VarChar, 50);
            para.Value = userLoginName;
            cmd.Parameters.Add(para);
            try {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader(); // 将检索的记录行填充到DataReader对象dr中
                if (dr.Read())  // 如果用户存在
                {
                    if (dr.GetString(2) == userPassword)    // 如果密码正确，转入留言列表页面
                    {    // 使用Session来保存管理员登录名信息
                        Session.Add("admin", userLoginName);
                        // 使用Session来保存用户登录名信息
                        Session.Add("login_name", userLoginName);
                        Response.Redirect("TopicAdmin.aspx");
                    } else        // 如果密码错误，给出提示，光标停留在密码框中
                      {
                        Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
                    }
                } else   // 如果用户不存在
                  {
                    Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
                }
                dr.Close();  // 关闭DataReader对象
            } catch (SqlException sqlException) {
                Response.Write(sqlException.Message);   // 显示连接异常信息
            } finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}