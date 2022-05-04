using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class TeacherModifier
    {
        public bool DeleteTeacherById(int id)
        {
            var sql = @"DELETE FROM [dbo].[Teacher]
                        WHERE IdTeacher=@Id ";
            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            var sql = @"UPDATE [dbo].[Teacher]
                       SET [IdPerson] = @IdPerson,
                           [Matricola] = @Matricola,
                           [DataAssunzione] = @DataAssunzione
                     WHERE IdTeacher=@Id";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione);
            command.Parameters.AddWithValue("@Id", teacher.IdTeacher);

            var persModifier = new PersonModifier();

            return command.ExecuteNonQuery() > 0 && persModifier.UpdatePerson((Person)teacher);
        }
    }
}
