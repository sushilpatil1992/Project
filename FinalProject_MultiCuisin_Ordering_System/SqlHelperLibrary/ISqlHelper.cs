using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelperLibrary
{
    public interface ISqlHelper
    {
        void close();
        int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms);
        SqlDataReader ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] cmdParameters);
        object ExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] cmdParameters);
        void Open();
    }
}
