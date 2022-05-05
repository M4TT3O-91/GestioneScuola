using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;
using SchoolLibrary.Interface;

namespace SchoolLibrary.Persister
{
    public class ExamDetailPersister
    {
        public int AddExamDetail(ExamDetail examDetail)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdExam]
                                   ,[IdStudent])
                             VALUES
                                   (@IdExam
                                   ,@IdStudent);SELECT @@IDENTITY AS 'Identity';";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdExam", examDetail.IdExam);
            command.Parameters.AddWithValue("@IdStudent", examDetail.IdStudent);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
