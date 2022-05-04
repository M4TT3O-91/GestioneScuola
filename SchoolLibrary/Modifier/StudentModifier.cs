using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class StudentModifier
    {
        public bool DeleteStudentById(int id)
        {
            var sql = @"DELETE FROM [dbo].[Student]
                        WHERE Id=@Id ";
            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }
        public bool UpdateStudent(Student student)
        {
            var sql = @"UPDATE [dbo].[Student]
                       SET [IdPerson] = @IdPerson,
                           [Matricola] = @Matricola,
                           [DataIscrizione] = @DataIscrizione
                     WHERE @Id=Id";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Matricola", student.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", student.DataIscrizione);
            
            var persModifier = new PersonModifier();
            
            return command.ExecuteNonQuery() > 0 && persModifier.UpdatePerson((Person)student);
        }
    }
}
