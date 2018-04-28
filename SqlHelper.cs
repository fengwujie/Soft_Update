using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Soft_Update
{
    public class SqlHelper
    {
        public string ConnectionString = "";
        SqlConnection connection;
        public SqlHelper()
        {            
        }

        void ParseParameters(SqlCommand Command, SqlParameter[] Pars)
        {
            if (Pars != null && Pars.Length > 0 && Command != null)
            {
                foreach (SqlParameter par in Pars)
                    Command.Parameters.Add(par);
            }
        }

        SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new SqlConnection(this.ConnectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        public void CloseConnection()
        {
            try
            {
                if (connection == null)
                    return;
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            catch (Exception ex)
            { }
        }

        public int ExecuteNonQuery(string CmdText)
        {
            int result = 0;
            result = this.ExecuteNonQuery(CmdText, CommandType.Text, null);
            return result;
        }

        public int ExecuteNonQuery(string CmdText, CommandType CmdType)
        {
            int result = 0;
            result = this.ExecuteNonQuery(CmdText, CmdType, null);
            return result;
        }

        public int ExecuteNonQuery(string CmdText, SqlParameter[] Pars)
        {
            int result = 0;
            result = this.ExecuteNonQuery(CmdText, CommandType.Text, Pars);
            return result;
        }

        public int ExecuteNonQuery(string CmdText, CommandType CmdType, SqlParameter[] Pars)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = CmdText;
                cmd.CommandType = CmdType;
                cmd.Connection = this.GetConnection();
                this.ParseParameters(cmd, Pars);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        public DataSet ExecuteDataSet(string CmdText)
        {
            DataSet result = null;
            result = this.ExecuteDataSet(CmdText, CommandType.Text, null);
            return result;
        }

        public DataSet ExecuteDataSet(string CmdText, CommandType CmdType)
        {
            DataSet result = null;
            result = this.ExecuteDataSet(CmdText, CmdType, null);
            return result;
        }

        public DataSet ExecuteDataSet(string CmdText, SqlParameter[] Pars)
        {
            DataSet result = null;
            result = this.ExecuteDataSet(CmdText, CommandType.Text, Pars);
            return result;
        }

        public DataSet ExecuteDataSet(string CmdText, CommandType CmdType, SqlParameter[] Pars)
        {
            DataSet result = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = CmdText;
                cmd.CommandType = CmdType;
                cmd.Connection = this.GetConnection();
                this.ParseParameters(cmd, Pars);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        public object ExecuteScalar(string CmdText)
        {
            object result = 0;
            result = this.ExecuteScalar(CmdText, CommandType.Text, null);
            return result;
        }

        public object ExecuteScalar(string CmdText, CommandType CmdType)
        {
            object result = 0;
            result = this.ExecuteScalar(CmdText, CmdType, null);
            return result;
        }

        public object ExecuteScalar(string CmdText, SqlParameter[] Pars)
        {
            object result = 0;
            result = this.ExecuteScalar(CmdText, CommandType.Text, Pars);
            return result;
        }

        public object ExecuteScalar(string CmdText, CommandType CmdType, SqlParameter[] Pars)
        {
            object result = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = CmdText;
                cmd.CommandType = CmdType;
                cmd.Connection = this.GetConnection();
                this.ParseParameters(cmd, Pars);
                result = cmd.ExecuteScalar();                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        public SqlDataReader GetDataReader(string CmdText)
        {
            SqlDataReader result = this.GetDataReader(CmdText, CommandType.Text, null);
            return result;
        }

        public SqlDataReader GetDataReader(string CmdText, CommandType CmdType)
        {
            SqlDataReader result = this.GetDataReader(CmdText, CmdType, null);
            return result;
        }

        public SqlDataReader GetDataReader(string CmdText, SqlParameter[] Pars)
        {
            SqlDataReader result = this.GetDataReader(CmdText, CommandType.Text, Pars);
            return result;
        }

        public SqlDataReader GetDataReader(string CmdText, CommandType CmdType, SqlParameter[] Pars)
        {            
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = CmdText;
                cmd.CommandType = CmdType;
                cmd.Connection = this.GetConnection();
                this.ParseParameters(cmd, Pars);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }  
        }
    }
}
