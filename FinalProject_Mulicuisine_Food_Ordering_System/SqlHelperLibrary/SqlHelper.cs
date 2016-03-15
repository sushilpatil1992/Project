using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperLibrary
{
    public class SqlHelper : IDisposable, ISqlHelper
    {
        private SqlCommand command;
        private SqlConnection connection;

        private SqlHelper()
        {        }
        public SqlHelper(string conString)
        {
            ConnectionString = conString;
        }
        public String ConnectionString
        {
            get { return ConnectionString; }
            set { ConnectionString = value; }
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] cmdParameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
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
    }
 }
