using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class SubjectPersister
    {
        public int AddSubject(Subject subject)
        {
            var sql = @"
                        INSERT INTO [dbo].[Subject]
                                   ([Name]
                                   ,[Description]
                                   ,[Credits]
                                   ,[Hours])
                             VALUES
                                   (@Name
                                   ,@Description
                                   ,@Credits
                                   ,@Hours);SELECT @@IDENTITY AS 'Identity';";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@Credits", subject.Credits);
            command.Parameters.AddWithValue("@Hours", subject.Hours);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
