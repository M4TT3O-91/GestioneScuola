using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

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

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", examDetail.IdExam);
            command.Parameters.AddWithValue("@Matricola", examDetail.IdStudent);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
