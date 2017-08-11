using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        int maxnum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnReg_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            conn.Open();
            // 检查用户是否已存在
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = conn;
            Cmd.CommandText = "select [LoginName] from [User]";
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetString(0).Trim() == TxtName.Text)
                {
                    LblCaution.Text = TxtName.Text + "已经存在，请你选择另外的登录名！";
                    conn.Close();
                    return;
                }
            }
            conn.Close();
            string SqlStr;
            SqlStr = "Insert into [User]([LoginName],[UserName],[Password],[Address],[Homepage],[Email]) values(@LoginName,@UserName,@Password,@Address,@Homepage,@Email)";
            Cmd.CommandText = SqlStr;
            // 添加参数对象,并给参数赋值
            SqlParameter para1 = new SqlParameter("@LoginName", SqlDbType.VarChar, 50);
            para1.Value = TxtLoginName.Text;
            Cmd.Parameters.Add(para1);
            SqlParameter para2 = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            para2.Value = TxtName.Text;
            Cmd.Parameters.Add(para2);
            SqlParameter para3 = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            para3.Value = TxtPass.Text;
            Cmd.Parameters.Add(para3);
            SqlParameter para4 = new SqlParameter("@Address", SqlDbType.VarChar, 100);
            para4.Value = TxtAddress.Text;
            Cmd.Parameters.Add(para4);
            SqlParameter para5 = new SqlParameter("@Homepage", SqlDbType.VarChar, 50);
            para5.Value = TxtHomePage.Text;
            Cmd.Parameters.Add(para5);
            SqlParameter para6 = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            para6.Value = TxtEmail.Text;
            Cmd.Parameters.Add(para6);
            try
            {
                conn.Open();            // 打开数据库连接
                Cmd.ExecuteNonQuery();      // 将添加记录
                LblCaution.Text = "恭喜你，你已注册成功！";
            }
            catch (SqlException sqlException)
            {
                Response.Write(sqlException.Message);   // 显示连接异常信息
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            TxtLoginName.Text = "";
            TxtName.Text = "";
            TxtPass.Text = "";
            TxtAddress.Text = "";
            TxtHomePage.Text = "";
            TxtEmail.Text = "";
            LblCaution.Text = "";
            Response.Write("<script language=javascript>alert('用户已取消注册！');</script>");
        }
    }
}