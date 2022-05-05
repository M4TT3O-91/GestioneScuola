using SchoolLibrary.Model;
using SchoolLibrary.Modifier;
using SchoolLibrary.Persister;
using SchoolLibrary.Retriver;

namespace School_Main.Methods
{
    public static class StudentHandler
    {
        public static int AddStudent()
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

            Console.Write("Data Iscrizione (aaaa-mm-gg): ");
            var iscr = DateTime.Parse(Console.ReadLine());

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

            var student = new Student
            {
                Id = person.Id,
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
                Matricola = matricola,
                DataIscrizione = iscr,
            };
            var studentPersister = new StudentPersister();
            return studentPersister.AddStudent(student);
        }

        public static IEnumerable<Student> ReadAllStudent()
        {
            var studentRetriver = new StudentRetriver();
            var studentList = studentRetriver.GetAllStudent();
            return studentList;
        }

        public static bool UpdateStudent()
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

            Console.Write("ID Studente: ");
            int.TryParse(Console.ReadLine(), out int idStud);

            Console.Write("Matricola: ");
            var matricola = Console.ReadLine();

            Console.Write("Data Iscrizione (aaaa-mm-gg): ");
            var iscr = DateTime.Parse(Console.ReadLine());

            var student = new Student
            {
                Id = id,
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
                IdStudent = idStud,
                Matricola = matricola,
                DataIscrizione = iscr,
            };

            var studentModifier = new StudentModifier();
            return studentModifier.UpdateStudent(student);
        }
    }
}
