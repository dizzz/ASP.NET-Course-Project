﻿using System;
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
    public partial class TopicAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {   // 新建数据库连接conn，连接到SQL SERVER数据库
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();  // 新建Command对象
            cmd.Connection = conn;
            cmd.CommandText = "Insert into [Topic]([UserLoginName],[Title],[Content],[CreateTime],[IP]) Values(@UserLoginName,@Title,@Content,@CreateTime,@IP)";
            cmd.CommandType = CommandType.Text;
            // 添加查询参数对象,并给参数赋值
            SqlParameter para1 = new SqlParameter("@UserLoginName", SqlDbType.VarChar, 50);
            para1.Value = Session["login_name"].ToString();
            cmd.Parameters.Add(para1);
            SqlParameter para2 = new SqlParameter("@Title", SqlDbType.VarChar, 50);
            para2.Value = TextBoxTitle.Text;
            cmd.Parameters.Add(para2);
            SqlParameter para3 = new SqlParameter("@Content", SqlDbType.Text);
            para3.Value = TextBoxContent.Text;
            cmd.Parameters.Add(para3);
            SqlParameter para4 = new SqlParameter("@CreateTime", SqlDbType.DateTime);
            para4.Value = DateTime.Now;
            cmd.Parameters.Add(para4);
            SqlParameter para5 = new SqlParameter("@IP", SqlDbType.VarChar, 15);
            para5.Value = Request.ServerVariables["REMOTE_HOST"];
            cmd.Parameters.Add(para5);
            try
            {
                conn.Open();  // 打开数据库连接
                cmd.ExecuteNonQuery();  //将添加记录
                Response.Redirect("TopicList.aspx");
            }
            catch (SqlException sqlException)
            {
                Response.Write(sqlException.Message);  // 显示连接异常信息
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TopicList.aspx");
        }

    }
}