using Microsoft.Data.SqlClient;
using SchoolLibrary.Model;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;

namespace SchoolLibrary.Persister
{
    public class TeacherPersister
    {
        public int AddTeacher(Teacher teacher)
        {
            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([IdPerson]
                                   ,[Matricola]
                                   ,[DataAssunzione])
                             VALUES
                                   (@IdPerson
                                   ,@Matricola
                                   ,@DataAssunzione);SELECT @@IDENTITY AS 'Identity';";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione);
         
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
