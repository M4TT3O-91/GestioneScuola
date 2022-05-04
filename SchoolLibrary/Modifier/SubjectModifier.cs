using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;


namespace SchoolLibrary.Modifier
{
    public class SubjectModifier
    {
        public bool DeleteSubjectById(int id)
        {
            var sql = @"DELETE FROM [dbo].[Subject]
                        WHERE Id=@Id ";
            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateSubject(Subject subject)
        {
            var sql = @"UPDATE [dbo].[Class]
                       SET [Name] = @Name,
                           [Description] = @Description,
                           [Credits] = @Credits,
                           [Hours] = @Hours
                     WHERE @Id=Id";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@Credits", subject.Description);
            command.Parameters.AddWithValue("@Hours", subject.Hours);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
