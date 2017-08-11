using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 实验10
{
    public partial class Register : System.Web.UI.Page
    {

        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show_Table();
            }
        }
        protected void Show_Table()
        {
            string cmdtxt = "SELECT * FROM[user]";
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdtxt, Con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }
        protected void BtnReg_Click(object sender, EventArgs e)
        {
            string cmdtxt = "Insert into [user]([uname],[upassword],[email],[phone]) VALUES('" + this.txtUname.Text + "'";
                cmdtxt += ",'" + this.txtPwd.Text + "','" + this.txtEmail.Text + "','" + this.txtPhone.Text + "');";
                localhost.Service InsertData = new localhost.Service();
             bool i = InsertData.CommandSql(ConnectionString, cmdtxt);
            
            //Response.Write(cmdtxt);
            
            if (i == true)
            {
                Response.Write("<script>alert('添加成功！');location='Register.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');location='Register.aspx'</script>");
            }
            Show_Table();
            
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.txtUname.Text = "";
            this.txtPwd.Text = "";
            this.txtEmail.Text = "";
            this.txtPhone.Text = "";
        }
    }
}