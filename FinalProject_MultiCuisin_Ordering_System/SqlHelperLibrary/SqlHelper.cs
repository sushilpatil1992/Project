using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperLibrary
{
    public class SqlHelper
    {
        private SqlCommand command;
        private SqlConnection connection;
        public String connectionString;
        public String ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private SqlHelper()
        {

        }

        public SqlHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Open()
        {
            SqlConnection consql = new SqlConnection();
            consql.ConnectionString = connectionString;
            connection.Open();
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] cmdParameters)
        {

            SqlConnection con = new SqlConnection(connectionString);

            if (con.State == ConnectionState.Closed)
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText,con);
                PrepareCommand(cmd, con, null, cmdType, cmdText, cmdParameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);                
           
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] cmdParameters)
        {
           if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlCommand cmdSql = new SqlCommand(cmdText, connection);
            return cmdSql.ExecuteScalar();
        }

        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public void Dispose()
        {
            command.Dispose();
            connection.Dispose();
        }
        public void close()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
