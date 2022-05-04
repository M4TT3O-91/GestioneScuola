using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class TeacherRetriver
    {
        public IEnumerable<Teacher> GetTeacherById(int IdTeacher)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdPerson]
                          ,[Matricola]
                          ,[DataAssunzione]
                      FROM [dbo].[Teacher]
                        where Id =@IdTeacher";


            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", IdTeacher);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Teacher
                {
                    IdTeacher = Convert.ToInt32(reader["Id"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    Matricola = reader["Matricola"].ToString(),
                    DataAssunzione = Convert.ToDateTime(reader["Birthday"]),
                };
            }

        }
    }
}
