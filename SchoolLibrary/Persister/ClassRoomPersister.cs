using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class ClassRoomPersister
    {
        public bool AddStudent(ClassRoom student)
        {
            var sql = @"
                        INSERT INTO [dbo].[Class]
                                   ([IdStudent]
                                   ,[IdLesson])
                             VALUES
                                   (@IdStudent
                                   ,@IdLesson)";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", student.IdStudent);
            command.Parameters.AddWithValue("@IdLesson", student.IdLesson);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
