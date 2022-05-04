﻿using Microsoft.Data.SqlClient;
using SchoolLibrary.Costants;
using SchoolLibrary.Interface;
using SchoolLibrary.Model;

namespace SchoolLibrary.Retriver
{
    public class StudentRetriver
    {
        public IEnumerable<Student> GetStudentrById(int IdStudent)
        {

            var sql = @"select p.id,p.Name, p.Surname, p.BirthDay,p.Address,p.Gender,s.Matricola,s.DataIscrizione
                        from Student s
                        join person p on p.Id = s.IdPerson
                        where p.Id = @IdStudent";


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
                };
            }
        }
    }
}
