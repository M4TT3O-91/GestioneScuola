

using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class LessonPersister
    {
        public bool AddLesson(Lesson lesson)
        {
            var sql = @"
                        INSERT INTO [dbo].[Lesson]
                                   ([IdTeacher]
                                   ,[IdSubject])
                             VALUES
                                   (@IdTeacher
                                   ,@IdSubject)";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", lesson.IdTeacher);
            command.Parameters.AddWithValue("@Matricola", lesson.IdSubject);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
