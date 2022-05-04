using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class ExamRetriver
    {
        public IEnumerable<Exam> GetExam(int IdExam)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdTeacher]
                          ,[Date]
                          ,[IdSubject]
                      FROM [dbo].[Class]
                        where Id =@IdExam";


            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdExam", IdExam);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Exam
                {
                    IdExam = Convert.ToInt32(reader["Id"]),
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    IdSubject = Convert.ToInt32(reader["IdLesson"]),
                    Date = Convert.ToDateTime(reader["Date"]),
                };
            }

        }
    }
}
