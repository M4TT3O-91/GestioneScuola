using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;
using SchoolLibrary.Interface;

namespace SchoolLibrary.Persister
{
    public class ExamDetailPersister
    {
        public bool AddExamDetail(ExamDetail examDetail)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdExam]
                                   ,[IdStudent])
                             VALUES
                                   (@IdExam
                                   ,@IdStudent)";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", examDetail.IdExam);
            command.Parameters.AddWithValue("@Matricola", examDetail.IdStudent);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
