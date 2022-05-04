using SchoolLibrary.Costants;

namespace SchoolLibrary.Interface
{
    public class SQLConnection : Connection
    {
        public string GetConnectionString()
        {
            return EnvConstants.CONNECTION_STRING;
        }
    }
}
