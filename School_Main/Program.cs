using SchoolLibrary.Model;
using SchoolLibrary.Persister;
using SchoolLibrary.Modifier;
using SchoolLibrary.Retriver;
using School_Main.Methods;

var input = "h";

while (input != "exit")
{
    switch (input)
    {
        case "help":
        case "h":
            Console.WriteLine("*----------------------------- LISTA COMANDI -----------------------------------*");
            Console.WriteLine("|  h, help              -- per vedere i comandi                                 |");
            Console.WriteLine("|  exit                 -- per uscire                                           |");
            Console.WriteLine("|-- Persona --------------------------------------------------------------------|");
            Console.WriteLine("|  add person           -- per aggiungere una persona                           |");
            Console.WriteLine("|  print all persons    -- per vedere le persone tutte le persone registrate    |");
            Console.WriteLine("|  update person        -- per aggiornare una persona                           |");
            Console.WriteLine("|-- Studente -------------------------------------------------------------------|");
            Console.WriteLine("|  add student          -- per aggiungere una persona                           |");
            Console.WriteLine("|  print all students   -- per vedere tutti gli studenti registrati             |");
            Console.WriteLine("|  update student       -- per aggiornare una persona                           |");
            Console.WriteLine("|-- Teacher --------------------------------------------------------------------|");
            Console.WriteLine("|  add teacher          -- per aggiungere un docente                            |");
            Console.WriteLine("|  print all teachers   -- per vedere tutti i docenti registrati                |");
            Console.WriteLine("|  update teacher       -- per aggiornare una docente                           |");
            Console.WriteLine("*-------------------------------------------------------------------------------*");
            break;
        case "add person":
            Console.WriteLine("loading...");
            Console.WriteLine(PersonHandler.AddPerson() != 0 ? "Persona aggiunta con successo" : "ATTENZIONE: qualcosa è andato storto" );
            break;
        case "print all persons":
            Console.WriteLine("**************** All PERSON ****************");
            foreach (var p in PersonHandler.ReadAllPerson().ToList<Person>())
                Console.WriteLine(p);
            break;
        case "update person":
            Console.WriteLine(PersonHandler.UpdatePerson() == true ? "Persona aggioranta correttamente" : "ATTENZIONE: persona non aggiornata");
            break;


        case "add student":
            Console.WriteLine("loading...");
            Console.WriteLine(StudentHandler.AddStudent() != 0 ? "Studente aggiunto con successo" : "ATTENZIONE: qualcosa è andato storto");
            break;
        case "print all students":
            Console.WriteLine("**************** All STUDENT ****************");
            foreach (var s in StudentHandler.ReadAllStudent().ToList<Student>())
                Console.WriteLine(s);
            break;
        case "update student":
            Console.WriteLine(StudentHandler.UpdateStudent() == true ? "Studente aggioranto correttamente" : "ATTENZIONE: Studente non aggiornato");
            break;


        case "add teacher":
            Console.WriteLine("loading...");
            Console.WriteLine(TeacherHandler.AddTeacher() != 0 ? "Docente aggiunto con successo" : "ATTENZIONE: qualcosa è andato storto");
            break;
        case "print all teachers":
            Console.WriteLine("**************** All Teacher ****************");
            foreach (var t in TeacherHandler.ReadAllTeacers().ToList<Teacher>())
                Console.WriteLine(t);
            break;
        case "update teacher":
            Console.WriteLine(TeacherHandler.UpdateTeacher() == true ? "Docente aggioranto correttamente" : "ATTENZIONE: Docente non aggiornato");
            break;


        default:
            Console.WriteLine("ATTENZIONE: Comando non trovato, controllare bene la sintassi");
            break;
    }
    Console.WriteLine();
    Console.Write("h per helper, exit per uscire: ");
    input = Console.ReadLine().ToLower();

}
