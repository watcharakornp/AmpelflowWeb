using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Security.Cryptography;
using AmpelflowWeb;
using AmpelflowWeb.DBConnect;

namespace AmpelflowWeb.xSetting
{
    public partial class usermanagement : System.Web.UI.Page
    {
        dbConnection dbConn = new dbConnection();
        string ssql;
        string strOpt = "";

        public string strTblDetail = "";

        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["emp_id"] != null)
                {
                    //todo something......



                }
                else
                {
                    Response.Redirect("../signin.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}