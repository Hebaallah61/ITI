using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Data;
using System.Configuration;

namespace DataAcessLayer
{
    public class DBManager
    {
        SqlConnection sqlcon;
        SqlDataAdapter sqlad;
        DataTable titledt;
        SqlCommand sqlcom;
        
        public DBManager()
        {
            try
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["pubs"].ConnectionString);
                sqlcom = new SqlCommand();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Connection= sqlcon;
                sqlad= new (sqlcom);
                titledt = new ();

                
            }
            catch
            {
                //log;
            }
        }

        public int ExecuteNonQuery(String spname)
        {
            //throw new NotImplementedException();
            try
            {
                sqlcom.Parameters.Clear ();
                sqlcom.CommandText= spname;
                if(sqlcon.State==ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                return sqlcom.ExecuteNonQuery();
            }
            catch
            {
                return-1;
            }
            finally
            {
                sqlcon.Close();
            }

        }


        public int ExecuteNonQuery(String spname,Dictionary<string,object> parmlst)
        {
            //throw new NotImplementedException();
            try
            {
                sqlcom.Parameters.Clear();
                foreach(var item in parmlst)
                {
                    sqlcom.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
                sqlcom.CommandText = spname;
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                return sqlcom.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlcon.Close();
            }

        }
        public object ExecuteScaler(String spname)
        {
            //throw new NotImplementedException();
            try
            {
                sqlcom.Parameters.Clear();
                sqlcom.CommandText = spname;
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                return sqlcom.ExecuteScalar();
            }
            catch
            {
                return new();
            }
            finally
            {
                sqlcon.Close();
            }
        }
        public DataTable ExecuteDataTable(String spname)
        {
            //throw new NotImplementedException();
            try
            {
                titledt.Clear();
                sqlcom.Parameters.Clear();
                sqlcom.CommandText = spname;
                sqlad.Fill(titledt);
                return titledt;
            }
            catch
            {
                return new();
            }
        }

    }
}