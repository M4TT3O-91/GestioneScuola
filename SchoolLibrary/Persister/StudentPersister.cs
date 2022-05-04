using SchoolLibrary.Model;
using SchoolLibrary.Costants;
using Microsoft.Data.SqlClient;

namespace SchoolLibrary.Persister
{
    public class StudentPersister
    {
        public int AddStudent(Student student)
        {
            var sql = @"
                        INSERT INTO [dbo].[Student]
                                   ([IdPerson]
                                   ,[Matricola]
                                   ,[DataIscrizione])
                             VALUES
                                   (@IdPerson
                                   ,@Matricola
                                   ,@DataIscrizione);SELECT @@IDENTITY AS 'Identity';"; 

            using var connection = new Interface.SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", student.Id);
            command.Parameters.AddWithValue("@Matricola", student.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", student.DataIscrizione);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
