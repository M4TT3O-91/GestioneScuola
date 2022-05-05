using SchoolLibrary.Model;
using SchoolLibrary.Modifier;
using SchoolLibrary.Persister;
using SchoolLibrary.Retriver;

namespace School_Main.Methods
{
    public static class PersonHandler
    {
        public static int AddPerson()
        {
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Cognome: ");
            var surname = Console.ReadLine();

            Console.Write("Data di nascita (aaaa-mm-gg): ");
            var birthDay = DateTime.Parse(Console.ReadLine());

            Console.Write("Genere: ");
            var gender = Console.ReadLine();

            Console.WriteLine("Indirizzo");
            var address = Console.ReadLine();

            var person = new Person
            {
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
            };
            var personPersister = new PersonPersister();
            return personPersister.AddPerson(person);
        }

        public static IEnumerable<Person> ReadAllPerson()
        {
            var personRetriver = new PersonRetriver();
            var personList = personRetriver.GetAllPerson();
            return personList;
        }

        public static bool UpdatePerson()
        {
            Console.WriteLine("Inserire i dati da modificare");
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(),out int id);

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

            var person = new Person
            {
                Id = id,
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Gender = gender,
                Address = address,
            };

            var personUpdater = new PersonModifier();
            return personUpdater.UpdatePerson(person);
        }

    }
}
