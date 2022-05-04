using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class SubjectPersister
    {
        public bool AddSubject(Subject subject)
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
                                   ,@Hours)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@Credits", subject.Credits);
            command.Parameters.AddWithValue("@Hours", subject.Hours);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
