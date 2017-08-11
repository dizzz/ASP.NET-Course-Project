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
    public partial class TopicDetail : System.Web.UI.Page {
        private void InitData() {   // 获取链接传递的参数值
            int topicID = Convert.ToInt32(Request.QueryString["topic_id"]);
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyBBS_DataConnectionString"].ConnectionString;
            SqlDataReader dr; // 新建DataReader对象
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM [Topic] where TopicID=@TopicID";
            cmd.CommandType = CommandType.Text;
            // 添加查询参数对象,并给参数赋值
            SqlParameter para = new SqlParameter("@TopicID", SqlDbType.Int);
            para.Value = topicID;
            cmd.Parameters.Add(para);
            try {
                conn.Open(); // 打开数据库连接
                dr = cmd.ExecuteReader(); // 将检索的记录行填充到DataReader对象中
                if (dr.Read()) {
                    LabelTitle.Text = System.Web.HttpUtility.HtmlEncode(dr.GetString(2));
                    LabelContent.Text = System.Web.HttpUtility.HtmlEncode(dr.GetString(3));
                    LabelCreateTime.Text = dr.GetDateTime(4).ToString();
                    LabelIP.Text = dr.GetString(5);
                    LabelUserLoginName.Text = dr.GetString(1);
                }
                dr.Close();
            } catch (SqlException sqlException) {
                Response.Write(sqlException.Message); // 显示连接异常信息
            } finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack)
                InitData();
        }
        protected void ButtomBack_Click(object sender, EventArgs e) {
            Response.Redirect("TopicList.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e) {
            String url = Convert.ToString(Request.QueryString["topic_id"]);
            url = "TopicReply.aspx?topic_id=" + url;
            Response.Redirect(url);
        }
    }
}