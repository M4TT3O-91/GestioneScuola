using SchoolLibrary.Model;
using SchoolLibrary.Modifier;
using SchoolLibrary.Persister;
using SchoolLibrary.Retriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Main.Methods
{
    public static class TeacherHandler
    {
        public static int AddTeacher()
        {
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Cognome: ");
            var surname = Console.ReadLine();

            Console.Write("Data di nascita (aaaa-mm-gg): ");
            var birthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Genere: ");
            var gender = Console.ReadLine();

            Console.Write("Indirizzo: ");
            var address = Console.ReadLine();

            Console.Write("Matricola: ");
            var matricola = Console.ReadLine();

            Console.Write("Data Assunzione (aaaa-mm-gg): ");
            var assunz = DateTime.Parse(Console.ReadLine());

            var person = new Person
            {
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
            };

            var personPersister = new PersonPersister();
            person.Id = personPersister.AddPerson(person);

            var teacher = new Teacher
            {
                Id = person.Id,
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
                Matricola = matricola,
                DataAssunzione = assunz,
            };
            var teacherPersister = new TeacherPersister();
            return teacherPersister.AddTeacher(teacher);
        }

        public static IEnumerable<Teacher> ReadAllTeacers()
        {
            var teacherRetriver = new TeacherRetriver();
            var teacherList = teacherRetriver.GetAllTeachers();
            return teacherList;
        }

        public static bool UpdateTeacher()
        {
            Console.WriteLine("Inserire i dati da modificare");
            Console.Write("ID Persona: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Cognome: ");
            var surname = Console.ReadLine();

            Console.Write("Data di nascita (aaaa-mm-gg): ");
            var birthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Genere: ");
            var gender = Console.ReadLine();

            Console.Write("Indirizzo:");
            var address = Console.ReadLine();

            Console.Write("ID Docente: ");
            int.TryParse(Console.ReadLine(), out int idStud);

            Console.WriteLine("Matricola: ");
            var matricola = Console.ReadLine();

            Console.WriteLine("Data Assunzione (aaaa-mm-gg): ");
            var assunz = DateTime.Parse(Console.ReadLine());

            var teacher = new Teacher
            {
                Id = id,
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
                IdTeacher = idStud,
                Matricola = matricola,
                DataAssunzione = assunz,
            };

            var teacherModifier = new TeacherModifier();
            return teacherModifier.UpdateTeacher(teacher);
        }
    }
}
