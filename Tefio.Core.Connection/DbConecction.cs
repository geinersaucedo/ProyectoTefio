using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace Tefio.Core.Connection
{
    public class DbConecction
    {
        public SqlConnection Connection { get; set; }
        public DbConecction(String ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }
    }
}
