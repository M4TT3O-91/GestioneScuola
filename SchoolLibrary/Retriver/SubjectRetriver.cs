using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class SubjectRetriver
    {
        public IEnumerable<Subject> GetSubjectById(int IdSubject)
        {

            var sql = @"
                    SELECT [Id]
                          ,[IdName]
                          ,[Description]
                          ,[Credits]
                          ,[Hours]
                      FROM [dbo].[Subject]
                        where Id =@IdSubject";


            using var connection = new SqlConnection(EnvConstants.CONNECTION_STRING);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", IdSubject);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Subject
                {
                    IdSubject = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Credits = Convert.ToInt32(reader["Credits"]),
                    Hours = Convert.ToInt32(reader["Hours"]),
                };
            }
        }
    }
}
