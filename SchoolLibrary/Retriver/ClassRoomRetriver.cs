using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class ClassRoomRetriver
    {
        public IEnumerable<ClassRoom> GetClassRoomById(int IdClass)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdStudent]
                          ,[IdLesson]
                      FROM [dbo].[Class]
                        where Id =@IdClass";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdClass", IdClass);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new ClassRoom
                {
                    IdClass = Convert.ToInt32(reader["Id"]),
                    IdLesson = Convert.ToInt32(reader["IdLesson"]),
                    IdStudent = Convert.ToInt32(reader["IdStudent"]),
                };
            }

        }
    }
}