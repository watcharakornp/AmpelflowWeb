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
//using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;
using AmpelflowWeb.DBConnect;

namespace AmpelflowWeb.xSetting
{
    public partial class createmenupages : System.Web.UI.Page
    {        
        dbConnection dbConn = new dbConnection();
        string ssql;
        //string strOpt = "";

        public string strTblDetail = "";

        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["emp_id"] != null)
                {

                    //todo something......

                    //GetDataMenuAll();

                }
                else {
                    Response.Redirect("../signin.aspx");
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        //protected void GetDataMenuAll()
        //{
        //    try
        //    {
        //        ssql = "select * from vwGetDataMenuAll ";
        //        dt = new DataTable();
        //        dt = dbConn.GetDataTable(ssql);

        //        if (dt.Rows.Count != 0)
        //        {
        //            for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //            {

        //                string mnu_type_id = dt.Rows[i]["mnu_type_id"].ToString();
        //                string mnu_type_name = dt.Rows[i]["mnu_type_name"].ToString();
        //                string mnu_id = dt.Rows[i]["mnu_id"].ToString();
        //                string mnu_page = dt.Rows[i]["mnu_page"].ToString();
        //                string mnu_title = dt.Rows[i]["mnu_title"].ToString();

        //                strTblDetail += "<tr> " +
        //                                "     <td class=\"hidden\">" + mnu_type_id + "</td> " +
        //                                "     <td>" + mnu_type_name + "</td> " +
        //                                "     <td class=\"hidden\">" + mnu_id + "</td> " +
        //                                "     <td>" + mnu_page + "</td> " +
        //                                "     <td>" + mnu_title + "</td> " +
        //                                "     <td style=\"width: 20px; text-align: center;\"> " +
        //                                "       <a href=\"#\" title=\"Member\"><i class=\"fa fa-users text-green\"></i></a></td> " +
        //                                "     <td style=\"width: 20px; text-align: center;\"> " +
        //                                "       <a href=\"#\" title=\"Trash\"><i class=\"fa fa-trash-o text-red\"></i></a></td> " +
        //                                "</tr>";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}