

using SchoolLibrary.Model;

namespace SchoolLibrary.Interface
{
    public class PersonRet
    {
        public IEnumerable<Person> GetById(int id) {
            var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]
                        where Id =@id";
            using var command = new SQLCommandFactory().GetSqlReader(sql);
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
