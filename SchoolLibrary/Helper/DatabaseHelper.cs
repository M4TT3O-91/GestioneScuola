namespace SchoolLibrary.Helper
{
    public class DatabaseHelper
    {
        private readonly string ConnectionString;

        public DatabaseHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
