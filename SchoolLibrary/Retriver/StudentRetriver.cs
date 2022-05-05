using Microsoft.Data.SqlClient;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class StudentRetriver
    {
        public IEnumerable<Student> GetStudentById(int IdStudent)
        {
            var sql = @"SELECT p.Id,p.Name, p.Surname, p.BirthDay,p.Address,p.Gender,s.IdStudente,s.Matricola,s.DataIscrizione
                        FROM Student s
                        JOIN person p ON p.Id = s.IdPerson
                        WHERE p.Id = @IdStudent";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdStudent", IdStudent);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Student
                {
                    IdStudent = Convert.ToInt32(reader["Id"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    Matricola = reader["Matricola"].ToString(),
                    DataIscrizione = Convert.ToDateTime(reader["DataIscrizione"]),
                    
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDay = Convert.ToDateTime(reader["BirthDay"].ToString()),
                    Address = reader["Address"].ToString(),
                    Gender = reader["Gender"].ToString(),
                };
            }
        }

        public IEnumerable<Student> GetAllStudent()
        {
            var sql = @"SELECT p.Id,p.Name, p.Surname, p.BirthDay,p.Address,p.Gender,s.IdStudente,s.Matricola,s.DataIscrizione
                        FROM Student s
                        JOIN person p ON p.Id = s.IdPerson";

            using var connection = new SQLConnectionFactory().GetSQLConnection();
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Student
                {
                    IdStudent = Convert.ToInt32(reader["Id"]),
                    Id = Convert.ToInt32(reader["IdPerson"]),
                    Matricola = reader["Matricola"].ToString(),
                    DataIscrizione = Convert.ToDateTime(reader["DataIscrizione"]),

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
