using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class ExamDetailsModifier
    {
        public bool DeleteById(int id)
        {
            var sql = @"DELETE FROM [dbo].[ExamDetails]
                        WHERE Id=@Id ";
            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }
        public bool UpdateExamDetails(ExamDetail examDetails)
        {
            var sql = @"UPDATE [dbo].[ExamDetails]
                       SET [IdExam] = @IdExam
                          ,[IdStudent] = @IdStudent
                     WHERE @Id=Id";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdExam", examDetails.IdExam);
            command.Parameters.AddWithValue("@IdStudent", examDetails.IdStudent);
            command.Parameters.AddWithValue("@Id", examDetails.IdExamDetails);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
