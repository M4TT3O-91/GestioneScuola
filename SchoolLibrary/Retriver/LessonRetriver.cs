using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class LessonRetriver
    {
        public IEnumerable<Lesson> GetLessonById(int IdLesson)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdTeacher]
                          ,[IdSubject]
                      FROM [dbo].[Lesson]
                        where Id =@IdLesson";


            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdLesson", IdLesson);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Lesson
                {
                    IdLesson = Convert.ToInt32(reader["Id"]),
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    IdSubject = Convert.ToInt32(reader["IdLesson"]),
                };
            }

        }
    }
}
