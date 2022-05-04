using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolLibrary.Miscellaneous.Factory
{
    public abstract class FactoryConnection<T>
    {

        public abstract T GetConnection(string connectionString);

    }

    public class MySqlconnectionFactory : FactoryConnection<SqlConnection>
    {
        public override SqlConnection GetConnection(string connectionString) =>  new SqlConnection(connectionString);
        
    }

}
