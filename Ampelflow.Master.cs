using AmpelflowWeb.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmpelflowWeb
{
    public partial class Ampelflow : System.Web.UI.MasterPage
    {
        public string strActiveDashboard = "";
        public string strTextRedDashboard = "";
        public string strActiveMasterSetup = "";
        public string strTextCustomerType = "";
        public string strTextCustomerGrade = "";
        public string strTextProductGroup = "";
        public string strTextSpecifier = "";
        public string strTextArchitect = "";
        public string strTextCustomers = "";
        public string strTextProjectsetup = "";



        public string strActiveTransaction = "";
        public string strTextRequestForm = "";
        public string strTextArchitectCenter = "";
        public string strTextProjectCenter = "";
        public string strTextWeeklyReport = "";

        public string strFullName = "";
        public string strDept = "";

        public string strActiveReporting = "";
        public string strTextSaleWeeklyReport = "";
        public string strTextNewProjectReport = "";

        public string strTextReportForecasting = "";
        public string strTextSaleIntake = "";
        public string strTextCompanyReport = "";
        public string strTextArchitectReport = "";
        public string strTextProjectReport = "";

        public string strActiveActivity = "";
        public string strTextEventActivity = "";
        public string strTextPremiumGift = "";
        public string strTextSurprise = "";

        public string strSaleOnSpecActive = "";
        public string strTextSaleOnspec = "";
        public string strSaleOnSpecTrans = "";

        public string strMenuType = "";
        public string strMenuEnterprise = "";   // 1
        public string strMenuTransaction = "";  // 2
        public string strMenuReporting = "";    // 3
        public string strMenuHelp = "";         // 4
        public string strMenuSetting = "";      // 5

        public string strActEnterprise = "";
        public string strActTrans = "";
        public string strActReport = "";
        public string strActHelp = "";
        public string strActSetting = "";


        string ssql;
        string strOpt = "";

        DataTable dt;

        dbConnection dbConn = new dbConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {



                    if (!string.IsNullOrEmpty(Session["usr_id"] as string))
                    {
                        string strUsr_id = Session["usr_id"].ToString();
                        string strEmp_id = Session["emp_id"].ToString();
                        string strUsr_name = Session["usr_name"].ToString();
                        string strUsr_password = Session["usr_password"].ToString();

                        strOpt = Request.QueryString["opt"];

                        GetSystemMenu(strUsr_name, strUsr_password);
                        GetSystemActiveMenu(strOpt);
                    }
                    else
                    {

                        Response.Redirect("../signin.aspx", false);

                    }





                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    Response.Redirect("signin.aspx", false);
                }
            }


        }

        protected void GetSystemMenu(string strUsername, string strPassword)
        {
            ssql = "exec spGetEmployeeLogin '" + strUsername + "', '" + strPassword + "'";
            dt = new DataTable();
            dt = dbConn.GetDataTable(ssql);

            if (dt.Rows.Count != 0)
            {

                Session["mnu_id"] = dt.Rows[0]["mnu_id"].ToString();
                Session["mnu_type_id"] = dt.Rows[0]["mnu_type_id"].ToString();
                Session["mnu_page"] = dt.Rows[0]["mnu_page"].ToString();
                Session["mnu_title"] = dt.Rows[0]["mnu_title"].ToString();
                Session["mnu_seqno"] = dt.Rows[0]["mnu_seqno"].ToString();
                Session["emp_id"] = dt.Rows[0]["emp_id"].ToString();
                Session["mnu_type_id"] = dt.Rows[0]["mnu_type_id"].ToString();
                Session["mnu_type_name"] = dt.Rows[0]["mnu_type_name"].ToString();
                Session["sEmpFirstName"] = dt.Rows[0]["sEmpFirstName"].ToString();
                Session["sEmpLastName"] = dt.Rows[0]["sEmpLastName"].ToString();
                Session["sEmpEngFirstName"] = dt.Rows[0]["sEmpEngFirstName"].ToString();
                Session["sEmpEngLastName"] = dt.Rows[0]["sEmpEngLastName"].ToString();
                Session["sEmpNickName"] = dt.Rows[0]["sEmpNickName"].ToString();
                Session["sEmpJobTitle"] = dt.Rows[0]["sEmpJobTitle"].ToString();
                Session["sThaiName"] = dt.Rows[0]["sThaiName"].ToString();
                Session["sEmpBranch"] = dt.Rows[0]["sEmpBranch"].ToString();
                Session["sEmpBranchName"] = dt.Rows[0]["sEmpBranchName"].ToString();
                Session["sEmpOrg"] = dt.Rows[0]["sEmpOrg"].ToString();
                Session["usr_type_id"] = dt.Rows[0]["usr_type_id"].ToString();
                Session["type_desc"] = dt.Rows[0]["type_desc"].ToString();

                strFullName = Session["sEmpFirstName"] + " " + Session["sEmpLastName"];
                strDept = Session["sEmpOrg"].ToString();

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strMenuType = dt.Rows[i]["mnu_type_id"].ToString();

                    string strPageurl = dt.Rows[i]["mnu_page"].ToString();
                    string stMnu_title = dt.Rows[i]["mnu_title"].ToString();

                    if (strMenuType == "1")
                    {
                        strMenuEnterprise += "<li><a href =\"../../xenterprise/" + strPageurl + "?opt=etp\"><i class=\"fa fa-angle-right\"></i><span class=\"txtLabel\">" + stMnu_title + "</span></a></li>";
                    }
                    else if (strMenuType == "2")
                    {
                        strMenuTransaction += "<li><a href =\"../../xtransaction/" + strPageurl + "?opt=trn\"><i class=\"fa fa-angle-right\"></i><span class=\"txtLabel\">" + stMnu_title + "</span></a></li>";
                    }
                    else if (strMenuType == "3")
                    {
                        strMenuReporting += "<li><a href =\"../../xreporting/" + strPageurl + "?opt=rpt\"><i class=\"fa fa-angle-right\"></i><span class=\"txtLabel\">" + stMnu_title + "</span></a></li>";
                    }
                    else if (strMenuType == "4")
                    {
                        strMenuHelp += "<li><a href =\"../../xhelp/" + strPageurl + "?opt=hp\"><i class=\"fa fa-angle-right\"></i><span class=\"txtLabel\">" + stMnu_title + "</span></a></li>";
                    }
                    else if (strMenuType == "5")
                    {
                        strMenuSetting += "<li><a href =\"../../xsetting/" + strPageurl + "?opt=stt\"><i class=\"fa fa-angle-right\"></i><span class=\"txtLabel\">" + stMnu_title + "</span></a></li>";
                    }
                    else
                    {
                        strMenuEnterprise = null;
                        strMenuTransaction = null;
                        strMenuReporting = null;
                    }
                }
            }
        }

        protected void GetSystemActiveMenu(string strOpt)
        {

            if (strOpt == "etp") { strActEnterprise = "active"; } else { strActEnterprise = ""; }
            if (strOpt == "trn") { strActTrans = "active"; } else { strActTrans = ""; }
            if (strOpt == "rpt") { strActReport = "active"; } else { strActReport = ""; }
            if (strOpt == "hp") { strActHelp = "active"; } else { strActHelp = ""; }
            if (strOpt == "stt") { strActSetting = "active"; } else { strActSetting = ""; }

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.RemoveAll();
                Session.Abandon();

                string path = HttpContext.Current.Request.Url.AbsolutePath;

                if (path != "/Main")
                {
                    Response.Redirect("~/Main.aspx");
                }
                else
                {
                    Response.Redirect("SignIn.aspx");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}