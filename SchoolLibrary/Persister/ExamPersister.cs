using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class ExamPersister
    {
        public bool AddExam(Exam exam)
        {
            var sql = @"
                        INSERT INTO [dbo].[Exam]
                                   ([IdTeacher],
                                    [Date],
                                    [IdSubject])
                             VALUES
                                   (@IdStudent,
                                    @Date,
                                    @IdSubject)";

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
