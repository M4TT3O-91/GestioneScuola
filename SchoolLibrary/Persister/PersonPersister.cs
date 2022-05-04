using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Persister
{
    public class PersonPersister
    {

        public int AddPerson(Person person)
        {
            var sql = @"
                        INSERT INTO [dbo].[Person]
                                   ([Name],
                                   [Surname],
                                   [BirthDay],
                                   [Gender],
                                   [Address])
                             VALUES
                                   (@Name,
                                    @Surname,
                                    @BirthDay,
                                    @Gender,
                                    @Address);SELECT @@IDENTITY AS 'Identity'; ";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@SurName", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.BirthDay);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);


            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
