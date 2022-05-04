using SchoolLibrary.Costants;
using System.Data.SqlClient;

namespace SchoolLibrary.Miscellaneous.Factory
{
    public abstract class FactoryConnection<T>
    {
        public abstract T GetConnection();

    }

    public class MySqlconnectionFactory : FactoryConnection<SqlConnection>
    {
        public override SqlConnection GetConnection() =>  new SqlConnection(EnvConstants.CONNECTION_STRING);   
    }
}
