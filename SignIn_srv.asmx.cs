using AmpelflowWeb.DBConnect;
using AmpelflowWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace AmpelflowWeb
{
    /// <summary>
    /// Summary description for SignIn_srv
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SignIn_srv : System.Web.Services.WebService
    {
        dbConnection conn = new dbConnection();
        string ssql;
        string constr = ConfigurationManager.ConnectionStrings[dbConnect.ServNameDb].ToString();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void GetDataMemberSignIn(string macaddress)
        {
            List<cGetDataSignIn> members = new List<cGetDataSignIn>();
            SqlCommand comm = new SqlCommand("spGetRememberlist", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@macaddress", macaddress);

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGetDataSignIn cGetDataSignIn = new cGetDataSignIn();
                cGetDataSignIn.macaddress = rdr["macaddress"].ToString();
                cGetDataSignIn.username = rdr["username"].ToString();
                cGetDataSignIn.password = rdr["password"].ToString();
                cGetDataSignIn.isremember = Convert.ToInt32(rdr["isremember"]);
                members.Add(cGetDataSignIn);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(members));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetUpdaterememberSignIn(string update_by, string update_date, string macaddress, int isremember)
        {
            try
            {
                List<cGetDataSignIn> cGetDataSigns = new List<cGetDataSignIn>();
                using (SqlConnection cons = new SqlConnection(constr))
                {
                    cons.Open();
                    SqlCommand comm = new SqlCommand("spGetEditrememberuser", cons);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@update_by", update_by);
                    comm.Parameters.AddWithValue("@update_date", update_date);
                    comm.Parameters.AddWithValue("@macaddress", macaddress);
                    comm.Parameters.AddWithValue("@isremember", isremember);

                    comm.ExecuteNonQuery();

                    cons.Close();
                }
                List<string> stateStr = new List<string>();
                stateStr.Add("Success");

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(js.Serialize(stateStr));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                List<string> stateStr = new List<string>();
                stateStr.Add("UnSuccess");
                stateStr.Add(ex.Message.ToString());

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(js.Serialize(stateStr));
            }

        }

        [WebMethod]
        public void GetInsrememberSignIn(string create_by
            , string create_date
            , string username
            , string password
            , string macaddress
            , int isremember)
        {
            try
            {
                List<cGetDataSignIn> cGetDataSigns = new List<cGetDataSignIn>();
                using (SqlConnection cons = new SqlConnection(constr))
                {
                    cons.Open();
                    SqlCommand comm = new SqlCommand("spGetInsrememberuser", cons);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@create_by", create_by);
                    comm.Parameters.AddWithValue("@create_date", create_date);
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@password", password);
                    comm.Parameters.AddWithValue("@macaddress", macaddress);
                    comm.Parameters.AddWithValue("@isremember", isremember);

                    comm.ExecuteNonQuery();

                    cons.Close();
                }
                List<string> stateStr = new List<string>();
                stateStr.Add("Success");

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(js.Serialize(stateStr));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                List<string> stateStr = new List<string>();
                stateStr.Add("UnSuccess");
                stateStr.Add(ex.Message.ToString());

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(js.Serialize(stateStr));
            }

        }
    }
}

