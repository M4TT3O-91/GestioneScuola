using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class ClassRoomPersister
    {
        public int AddStudent(ClassRoom classRoom)
        {
            var sql = @"
                        INSERT INTO [dbo].[Class]
                                   ([IdStudent]
                                   ,[IdLesson])
                             VALUES
                                   (@IdStudent
                                   ,@IdLesson);SELECT @@IDENTITY AS 'Identity';";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", classRoom.IdStudent);
            command.Parameters.AddWithValue("@IdLesson", classRoom.IdLesson);

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
