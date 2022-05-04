using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class ExamModifier
    {
        public bool DeleteExamById(int id)
        {
            var sql = @"DELETE FROM [dbo].[Exam]
                        WHERE Id=@Id ";
            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }
        public bool UpdateExam(Exam exam)
        {
            var sql = @"UPDATE [dbo].[Exam]
                       SET [IdTeacher] = @IdTeacher,
                           [Date] = @Date,
                           [IdSubject] = @IdSubject,
                     WHERE @Id=Id";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", exam.IdTeacher);
            command.Parameters.AddWithValue("@Date", exam.Date);
            command.Parameters.AddWithValue("@IdSubject", exam.IdSubject);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
