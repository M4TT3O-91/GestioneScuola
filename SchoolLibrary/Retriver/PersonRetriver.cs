using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class PersonRetriver
    {
        public IEnumerable<Person> GetPersonByName(string name,string surname)
        {

            var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]
                        where Name = @name AND Surname =@surname";


            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
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

        public IEnumerable<Person> GetAllPerson()
        {

            var sql = @"
                    SELECT *
                    FROM Person";


            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Person
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    BirthDay = Convert.ToDateTime(reader["Birthday"]),
                    Address = reader["Address"].ToString(),
                };
            }

        }
    }
}
