using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BBS {
    public partial class TopicList : System.Web.UI.Page {
        private bool CheckUser()  //  验证用户是否登录
        {
            if (Session["login_name"] == null) {
                Response.Write("<Script Language=JavaScript>alert('请登录！');</Script>");
                return false;
            }
            return true;
        }
        private void InitData()   /// 按时间降序，读取帖子数据
        {    // 新建数据库连接conn，连接到SQL SERVER数据库
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            conn.Open(); // 打开数据库连接
            DataSet ds = new DataSet(); // 新建DataSet对象
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Topic] order by CreateTime desc", conn);
            da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
            conn.Close(); // 关闭数据库连接
            GV.DataSource = ds;  //设置数据源
            GV.DataBind();   //绑定数据源
            LabelPages.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!CheckUser())
                Response.Redirect("Login.aspx");
            if (!this.IsPostBack)
                InitData();
        }
        protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GV.PageIndex = e.NewPageIndex;
            InitData();  //刷新显示
        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e) {
            int index = Convert.ToInt32(e.CommandArgument); //待处理的行下标
            int topicId = -1;
            switch (e.CommandName) {    //删除
                case "Delete":
                    topicId = Convert.ToInt32(GV.Rows[index].Cells[0].Text);
                    deleteData(topicId);
                    InitData();
                    break;
                default:
                    break;
            }
        }
        private void deleteData(int topic_Id) // 删除帖子
        {   // 新建数据库连接conn，连接到SQL SERVER数据库
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM [Topic] where TopicID=@TopicID";
            cmd.CommandType = CommandType.Text;
            SqlParameter para = new SqlParameter("@TopicID", SqlDbType.Int);
            para.Value = topic_Id;
            cmd.Parameters.Add(para);
            try {
                conn.Open();  // 打开数据库连接
                cmd.ExecuteNonQuery();  //将添加记录
                Response.Redirect("TopicList.aspx");
            } catch (SqlException sqlException) {
                Response.Write(sqlException.Message);  // 显示连接异常信息
            } finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}