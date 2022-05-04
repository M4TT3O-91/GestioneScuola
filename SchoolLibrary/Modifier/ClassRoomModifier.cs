using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class ClassRoomModifier
    {
        public bool DeleteClassRoomById(int id)
        {
            var sql = @"DELETE FROM [dbo].[Class]
                        WHERE Id=@Id ";
            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateClass(ClassRoom classRoom)
        {
            var sql = @"UPDATE [dbo].[Class]
                       SET [IdStudent] = @IdStudent
                          ,[IdLesson] = @IdLesson
                     WHERE @Id=Id";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", classRoom.IdStudent);
            command.Parameters.AddWithValue("@IdLesson", classRoom.IdLesson);
            command.Parameters.AddWithValue("@Id", classRoom.IdClass);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
