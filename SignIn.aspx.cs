using AmpelflowWeb.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmpelflowWeb
{
    public partial class SignIn : System.Web.UI.Page
    {
        dbConnection dbConn = new dbConnection();
        
        string ssql;
        DataTable dt = new DataTable();

        public static string strErorConn = "";

        SqlConnection Conn = new SqlConnection();
        SqlCommand Comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlTransaction transac;
        public string sMacAddress = "";
        public string strMsgAlert = "";
        public string strTblDetail = "";
        public string strTblActive = "";


        public string userName1 = "";
        public string passWord1 = "";
        public int rememberVal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetMACAddress();

            if (!IsPostBack)
            {
                strErorConn = "";
            }
            else
            {
                strErorConn = "";
            }
        }

        protected void btnSignIn_click(object sender, EventArgs e)
        {

           

            try
            {
                
                string strUserName = txtUsername.Value.ToString();
                string strPassWord = txtPassword.Value.ToString();
                string strRememState = checkboxval.Value.ToString();
                string strDate = DateTime.Now.ToString("yyyy-MM-dd");

                ssql = "exec spGetUserLogin '" + strUserName + "', '" + strPassWord + "' ";
                dt = new DataTable();
                dt = dbConn.GetDataTable(ssql);

                if (dt.Rows.Count > 0)
                {
                    Session["usr_id"] = dt.Rows[0]["usr_id"].ToString();
                    Session["emp_id"] = dt.Rows[0]["emp_id"].ToString();
                    Session["usr_name"] = dt.Rows[0]["usr_name"].ToString();
                    Session["usr_password"] = dt.Rows[0]["usr_password"].ToString();

                    Response.Redirect("Default.aspx", false);
                    // Response.Redirect("https://localhost:44344/xtransaction/invReport.aspx?opt=trn");

                }
                else
                {
                    strErorConn = " <div class=\"fad fad-in alert alert-danger input-sm\"> " +
                                "   <strong>Warning!</strong><br />Find not found username or password please check..!</div> ";
                    return;
                }
            }
            catch (Exception ex)
            {
                strErorConn = " <div class=\"fad fad-in alert alert-danger input-sm\"> " +
                                "   <strong>Warning!</strong><br />Incorrect username or password <br /> " + ex.Message + "</div> ";
            }
        }

        public string GetMACAddress()
        {
            int count = 0;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics)
            {
                if(count < 1)
                {
                    if (sMacAddress != null)// only return MAC Address from first card
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                        count++;
                    }
                }
            }
            return sMacAddress;
        }

        
    }
}