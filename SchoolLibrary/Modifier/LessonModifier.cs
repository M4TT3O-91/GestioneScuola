using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class LessonModifier
    {
        public bool DeleteLessonById(int id)
        {
            var sql = @"DELETE FROM [dbo].[Lesson]
                        WHERE Id=@Id ";
            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateClass(Lesson lesson)
        {
            var sql = @"UPDATE [dbo].[Lesson]
                       SET [IdTeacher] = @IdTeacher
                          ,[IdSubject] = @IdSubject
                     WHERE @Id=Id";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", lesson.IdTeacher);
            command.Parameters.AddWithValue("@IdSubject", lesson.IdSubject);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
