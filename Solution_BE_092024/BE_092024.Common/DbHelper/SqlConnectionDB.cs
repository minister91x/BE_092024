using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.Common.DbHelper
{
    public class SqlConnectionDB : DbConnection<SqlConnection>
    {
        SqlConnection _connection;

        public override SqlConnection DoConnect()
        {
            var connctionStr = "Server=DESKTOP-G9P0BPM;Database=BE_092024;User Id=sa;Password=123456;";
            _connection = new SqlConnection(connctionStr);

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }
    }
}
