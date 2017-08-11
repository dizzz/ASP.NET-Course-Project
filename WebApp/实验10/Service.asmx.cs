using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;


namespace 实验10
{
    /// <summary>
    ///Service 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        public Service()
        {
            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }
        [WebMethod]
        public bool CommandSql(string SqlConnectionString, string Cmdtxt)
        {
            System.Data.SqlClient.SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SqlConnectionString;
            try
            {
                conn.Open();
                SqlCommand Com = new SqlCommand(Cmdtxt, conn);
                Com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ms)
            {
                //System.Web.UI.Page tt = new System.Web.UI.Page();
                //tt.Response.Write(ms.Message);
                System.Diagnostics.Debug.Write(ms.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public double Sum(double a, double b)
        {
            return a + b;
        }
        [WebMethod]
        public double Sub(double a, double b)
        {
            return a - b;
        }
        [WebMethod]
        public double Mult(double a, double b)
        {
            return a * b;
        }
        [WebMethod]
        public double Div(double a, double b)
        {
            return a / b;
        }
    }
}
