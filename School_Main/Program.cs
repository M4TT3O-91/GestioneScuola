using SchoolLibrary.Model;
using SchoolLibrary.Persister;
using SchoolLibrary.Modifier;
using SchoolLibrary.Retriver;
using School_Main.Methods;

var personPersister = new PersonPersister();
var teacherPersister = new TeacherPersister();
var studentPersister = new StudentPersister();

var input = "h";

while (input != "exit")
{
    switch (input)
    {
        case "help":
        case "h":
            Console.WriteLine("*-------------------------------------------------------------------------------*");
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




//var person = new Person
//{
//    Address = "Largo Colombo",
//    BirthDay = new DateTime(1975, 6, 30),
//    Gender = "Male",
//    Name = "Nicola",
//    Surname = "Di Bari"
//};

//var person2 = new Person
//{
//    Address = "Vicolo corto",
//    BirthDay = new DateTime(1990, 4, 30),
//    Gender = "Female",
//    Name = "Sara",
//    Surname = "Rossi"
//};


//person.Id = personPersister.AddPerson(person);
//person2.Id = personPersister.AddPerson(person2);

//TeacherAdder(teacherPersister, person);
//StudentAdder(studentPersister, person2);

//printTeacher();
//printStudent();



//--------------------------------------------------------------------------
static void TeacherAdder(TeacherPersister teacherPersister, Person person)
{
    var teacher = new Teacher
    {
        Address = "Largo Colombo",
        BirthDay = new DateTime(1975, 6, 30),
        DataAssunzione = new DateTime(2001, 01, 05),
        Gender = "Male",
        Id = person.Id,
        Name = "Nicola",
        Surname = "Di Bari",
        Matricola = "ABDFDSF"
    };

    var idteacher = teacherPersister.AddTeacher(teacher);

    teacher = new Teacher
    {
        Address = "Largo Colombo",
        BirthDay = new DateTime(1974, 6, 30),
        DataAssunzione = new DateTime(2001, 01, 05),
        Gender = "Male",
        Id = person.Id,
        Name = "Nicola",
        Surname = "Bari",
        Matricola = "ABDFDSF",
        IdTeacher = idteacher
    };

    var modifierTeacher = new TeacherModifier();
    modifierTeacher.UpdateTeacher(teacher);
}

static void StudentAdder(StudentPersister studentPersister, Person person2)
{
    var student = new Student
    {
        Address = "Vicolo corto",
        BirthDay = new DateTime(1990, 4, 30),
        Gender = "Female",
        Name = "Sara",
        Surname = "Rossi",
        Id = person2.Id,
        DataIscrizione = new DateTime(2008, 5, 5),
        Matricola = "ABCDEF",
    };

    var idStudent = studentPersister.AddStudent(student);
    student = new Student
    {
        Address = "Vicolo corto",
        BirthDay = new DateTime(1990, 4, 30),
        Gender = "Female",
        Name = "Sara",
        Surname = "Rossi",
        Id = person2.Id,
        DataIscrizione = new DateTime(2008, 5, 5),
        Matricola = "ABCDEF",
        IdStudent = idStudent
    };

    var studentModifier = new StudentModifier();
    studentModifier.UpdateStudent(student);
}

static void printTeacher()
{
    Console.WriteLine("TEACHER:");
    var teacherRetriver = new TeacherRetriver();
    var teacherList = teacherRetriver.GetAllTeachers().ToList<Teacher>();
    foreach (var t in teacherList)
    {
        Console.WriteLine(t);
    }
    Console.WriteLine();
}

static void printStudent()
{
    Console.WriteLine("STUDENT:");
    var studentRetriver = new StudentRetriver();
    var studList = studentRetriver.GetAllStudent().ToList<Student>();
    foreach (var s in studList)
    {
        Console.WriteLine(s);
    }
    Console.WriteLine();
}