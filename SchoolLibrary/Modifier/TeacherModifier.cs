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
                        WHERE Id=@Id ";
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
                     WHERE @Id=Id";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione);

            var persModifier = new PersonModifier();

            return command.ExecuteNonQuery() > 0 && persModifier.UpdatePerson((Person)teacher);
        }
    }
}
