using Microsoft.Data.SqlClient;

namespace SchoolLibrary.Interface
{
    public class SQLCommandFactory
    {
        public SQLCommandFactory()
        {
            
        }

        public SqlCommand GetSqlReader(string Query)
        {
            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            return new SqlCommand(Query, connection); ;
        }
    }
}
