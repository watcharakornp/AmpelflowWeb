using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AmpelflowWeb.DBConnect
{
    public class dbConnection
    {
        string _ConnectionString;
        SqlConnection cn;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        public dbConnection()
        {
            //string strPath = HttpContext.Current.Server.MapPath("~/ClassConn/dbConnectionSQL.txt");


            //var ServerName = "invapp";
            var ReadString = ConfigurationManager.ConnectionStrings[dbConnect.ServNameDb].ToString();
            ConnectionString = ReadString;
        }

        public SqlConnection OpenConn()
        {
            cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public void CloseConn()
        {
            if (cn != null) cn.Close();
        }

        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                cn = OpenConn();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataSet GetDataSet(string sql, string dsname)
        {
            DataSet ds = new DataSet();
            try
            {
                cn = OpenConn();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(ds, "dataset");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataSet GetDataSet(string sql, string dsname, SqlTransaction trans)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, trans.Connection);
                da.SelectCommand.Transaction = trans;
                da.Fill(ds, "dataset");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                cn = OpenConn();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataTable GetDataTable(string sql, string dtname)
        {
            DataTable dt = new DataTable();
            try
            {
                cn = OpenConn();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataTable GetDataTable(string sql, string dtname, SqlTransaction trans)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, trans.Connection);
                da.SelectCommand.Transaction = trans;
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public SqlDataReader GetDataReader(string sql)
        {
            try
            {
                cn = OpenConn();
                SqlCommand comm = new SqlCommand(sql, cn);
                SqlDataReader dr = comm.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }

        public DataTable ExcuteDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }
    }
}