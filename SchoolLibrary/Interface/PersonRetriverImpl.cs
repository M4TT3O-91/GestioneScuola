using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Interface
{
    public class PersonRetriverImpl : IRetriver<Person>
    {
        public IEnumerable<Person> GetAll(int id)
        {
            var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]
                        where Id =@id";


            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Person
                {
                    BirthDay = Convert.ToDateTime(reader["Birthday"]),
                    Gender = reader["Gender"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Address = reader["Address"].ToString(),
                };

            }
        }
    }
}
