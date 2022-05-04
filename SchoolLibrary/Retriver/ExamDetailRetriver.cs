using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class ExamDetailRetriver
    {
        public IEnumerable<ExamDetail> GetExamDetailById(int IdExamDetail)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdExam]
                          ,[IdStudent]
                      FROM [dbo].[ExamDetail]
                        where Id =@IdExamDetail";


            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdExamDetail", IdExamDetail);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new ExamDetail
                {
                    IdExamDetails = Convert.ToInt32(reader["Id"]),
                    IdExam = Convert.ToInt32(reader["IdExam"]),
                    IdStudent = Convert.ToInt32(reader["IdStudent"]),
                };
            }

        }
    }
}
