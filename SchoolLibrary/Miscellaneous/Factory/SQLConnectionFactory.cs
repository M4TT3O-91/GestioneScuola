using Microsoft.Data.SqlClient;

namespace SchoolLibrary.Interface
{
    public class SQLConnectionFactory
    {
        public SQLConnectionFactory() { }

        public SqlConnection GetSQLConnection()
        {
            return new SqlConnection(new SQLConnection().GetConnectionString());
        }
    }
}
