using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class TeacherRetriver
    {
        public IEnumerable<Teacher> GetTeacherById(int IdTeacher)
        {

            var sql = @"
                        SELECT p.Id,p.Name, p.Surname, p.BirthDay,p.Address,p.Gender,t.IdTeacher,t.Matricola,t.DataAssunzione
                        FROM Teacher t
                        JOIN person p ON p.Id = t.IdPerson
                        where Id =@IdTeacher";


            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdTeacher", IdTeacher);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Teacher
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    Matricola = reader["Matricola"].ToString(),
                    DataAssunzione = Convert.ToDateTime(reader["Birthday"]),

                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDay = Convert.ToDateTime(reader["BirthDay"].ToString()),
                    Address = reader["Address"].ToString(),
                    Gender = reader["Gender"].ToString(),
                };
            }

        }

        public IEnumerable<Teacher> GetAllTeachers()
        {

            var sql = @"
                        SELECT p.Id,p.Name, p.Surname, p.BirthDay,p.Address,p.Gender,t.IdTeacher,t.Matricola,t.DataAssunzione
                        FROM Teacher t
                        JOIN person p ON p.Id = t.IdPerson";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Teacher
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdTeacher = Convert.ToInt32(reader["IdTeacher"]),
                    Matricola = reader["Matricola"].ToString(),
                    DataAssunzione = Convert.ToDateTime(reader["Birthday"]),

                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDay = Convert.ToDateTime(reader["BirthDay"].ToString()),
                    Address = reader["Address"].ToString(),
                    Gender = reader["Gender"].ToString(),
                };
            }

        }

    }
}
