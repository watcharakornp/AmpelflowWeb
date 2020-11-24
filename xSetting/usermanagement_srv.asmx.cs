using AmpelflowWeb;
using AmpelflowWeb.DBConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace PurchaseManu.xSetting
{
    /// <summary>
    /// Summary description for usermanagement_srv1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class usermanagement_srv1 : System.Web.Services.WebService
    {
        dbConnection conn = new dbConnection();

        [WebMethod]
        public void GetEmployeeList()
        {

            List<cGetEmployeeList> emps = new List<cGetEmployeeList>();
            SqlCommand comm = new SqlCommand("spGetEmployeeList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGetEmployeeList emp = new cGetEmployeeList();
                emp.emp_id = rdr["emp_id"].ToString();
                emp.prefix = rdr["prefix"].ToString();
                emp.firstname = rdr["firstname"].ToString();
                emp.lastname = rdr["lastname"].ToString();
                emp.username = rdr["username"].ToString();
                emp.name_desc = rdr["name_desc"].ToString();
                emp.urlview = rdr["urlview"].ToString();
                emp.urltrash = rdr["urltrash"].ToString();
                emps.Add(emp);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(emps));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetUserWithoutList()
        {
            List<cGetUserWithoutList> emps = new List<cGetUserWithoutList>();
            SqlCommand comm = new SqlCommand("spGetUserWithoutList", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGetUserWithoutList emp = new cGetUserWithoutList();
                emp.emp_id = rdr["emp_id"].ToString();
                emp.prefix = rdr["prefix"].ToString();
                emp.firstname = rdr["firstname"].ToString();
                emp.lastname = rdr["lastname"].ToString();
                emp.sEmpEngNamePrefix = rdr["sEmpEngNamePrefix"].ToString();
                emp.sEmpEngFirstName = rdr["sEmpEngFirstName"].ToString();
                emp.sEmpEngMiddleName = rdr["sEmpEngMiddleName"].ToString();
                emp.sEmpEngLastName = rdr["sEmpEngLastName"].ToString();
                emp.sEmpNickName = rdr["sEmpNickName"].ToString();
                emp.sEmpJobTitle = rdr["sEmpJobTitle"].ToString();
                emp.sThaiName = rdr["sThaiName"].ToString();
                emp.sEngName = rdr["sEngName"].ToString();
                emp.sEmpBranch = rdr["sEmpBranch"].ToString();
                emp.branch = rdr["branch"].ToString();
                emp.orglevel = rdr["orglevel"].ToString();
                emp.urllink = rdr["urllink"].ToString();
                emp.chk = rdr["chk"].ToString();
                emps.Add(emp);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(emps));
            conn.CloseConn();
        }

        [WebMethod]
        public void GetUserGroupType()
        {
            List<cGetUserGroupType> datas = new List<cGetUserGroupType>();
            SqlCommand comm = new SqlCommand("spGetUserType", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                cGetUserGroupType data = new cGetUserGroupType();
                data.usr_type_id = rdr["usr_type_id"].ToString();
                data.type_desc = rdr["type_desc"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(datas));
            conn.CloseConn();

        }

        [WebMethod]
        public void GetSavechangesUser(string usr_id, string emp_id, string usr_name, string usr_password, string usr_type_id, string isactive, string created_by, string create_date, string update_by, string update_date)
        {
            SqlCommand comm = new SqlCommand("spGetSavechangesUser", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@usr_id", usr_id);
            comm.Parameters.AddWithValue("@emp_id", emp_id);
            comm.Parameters.AddWithValue("@usr_name", usr_name);
            comm.Parameters.AddWithValue("@usr_password", usr_password);
            comm.Parameters.AddWithValue("@usr_type_id", usr_type_id);
            comm.Parameters.AddWithValue("@isactive", isactive);
            comm.Parameters.AddWithValue("@created_by", created_by);
            comm.Parameters.AddWithValue("@create_date", create_date);
            comm.Parameters.AddWithValue("@update_by", update_by);
            comm.Parameters.AddWithValue("@update_date", update_date);

            comm.ExecuteNonQuery();
            conn.CloseConn();

        }

        [WebMethod]
        public void GetEmployeeById(string empid)
        {

            List<cGetEmployeeById> datas = new List<cGetEmployeeById>();
            SqlCommand comm = new SqlCommand("spGetEmployeeById", conn.OpenConn());
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@empid", empid);

            SqlDataReader rdr = comm.ExecuteReader();

            while (rdr.Read())
            {

                cGetEmployeeById data = new cGetEmployeeById();
                data.emp_id = rdr["emp_id"].ToString();
                data.prefix = rdr["prefix"].ToString();
                data.firstname = rdr["firstname"].ToString();
                data.lastname = rdr["lastname"].ToString();
                data.username = rdr["username"].ToString();
                data.password = rdr["password"].ToString();
                data.name_desc = rdr["name_desc"].ToString();
                data.usr_type_id = rdr["usr_type_id"].ToString();
                data.isactive = rdr["isactive"].ToString();
                datas.Add(data);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(datas));
            Context.Response.ContentType = "application/json";
            conn.CloseConn();
        }

    }
}
