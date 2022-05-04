using System;
using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Modifier
{
    public class PersonModifier
    {
        public bool DeleteById(int IdPerson)
        {
            var sql = @"DELETE FROM [dbo].[Person]
                        WHERE Id=@Id ";
            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", IdPerson);
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdatePerson(Person person)
        {
            var sql = @"UPDATE [dbo].[Person]
                       SET [Name] = @Name
                          ,[Surname] = @Surname
                          ,[BirthDay] = @BirthDay
                          ,[Gender] = @Gender
                     WHERE @Id=Id";

            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.BirthDay);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Id", person.Id);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
