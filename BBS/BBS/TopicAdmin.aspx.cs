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
    public partial class TopicAdmin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.CheckUser())
                Response.Redirect("adminLogin.aspx");
            if (!this.IsPostBack)
                InitData();
        }
        private bool CheckUser() {
            if (Session["admin"] == null) {
                Response.Write("<Script Language=JavaScript>alert('请登录！');</Script>");
                return false;
            }
            return true;
        }
        private void InitData() {   // 新建数据库连接conn，连接到SQL SERVER数据库
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            DataSet ds = new DataSet();         // 新建DataSet对象
                                                // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Topic] order by CreateTime desc", conn);
            conn.Open();        // 打开数据库连接
            da.Fill(ds);            // 将检索的记录行填充到DataSet对象ds中
            conn.Close();       // 关闭数据库连接
            GV.DataSource = ds;
            GV.DataBind();
            LabelPages.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
        }
        private void deleteData(int topic_Id) {    // 新建数据库连接conn，连接到SQL SERVER数据库
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            SqlCommand cmd0 = new SqlCommand();
            cmd0.Connection = conn;
            cmd0.CommandText = "DELETE FROM [Reply] where TopicID=@TopicID";
            cmd0.CommandType = CommandType.Text;
            SqlParameter para0 = new SqlParameter("@TopicID", SqlDbType.Int);
            para0.Value = topic_Id;
            cmd0.Parameters.Add(para0);
            SqlCommand cmd = new SqlCommand();      // 新建Command对象
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM [Topic] where TopicID=@TopicID";
            cmd.CommandType = CommandType.Text;
            SqlParameter para = new SqlParameter("@TopicID", SqlDbType.Int);
            para.Value = topic_Id;
            cmd.Parameters.Add(para);
            try {
                conn.Open();            // 打开数据库连接
                cmd0.ExecuteNonQuery();     // 将删除回复记录
                cmd.ExecuteNonQuery();      // 将删除主帖记录
                Response.Redirect("TopicAdmin.aspx");
            } catch (SqlException sqlException) {
                Response.Write(sqlException.Message);   // 显示连接异常信息
            } finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument);   // 待处理的行下标
            int topicId = -1;
            switch (e.CommandName) {   // 删除
                case "Delete":
                    topicId = Convert.ToInt32(GV.Rows[index].Cells[0].Text);
                    deleteData(topicId);
                    InitData();
                    break;
                default:
                    break;
            }
        }
    }
}