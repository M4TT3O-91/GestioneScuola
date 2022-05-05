using SchoolLibrary.Model;
using SchoolLibrary.Persister;
using SchoolLibrary.Modifier;
using SchoolLibrary.Retriver;

var personPersister = new PersonPersister();
var teacherPersister = new TeacherPersister();
var studentPersister = new StudentPersister();

var person = new Person
{
    Address = "Largo Colombo",
    BirthDay = new DateTime(1975, 6, 30),
    Gender = "Male",
    Name = "Nicola",
    Surname = "Di Bari"
};

var person2 = new Person
{
    Address = "Vicolo corto",
    BirthDay = new DateTime(1990, 4, 30),
    Gender = "Female",
    Name = "Sara",
    Surname = "Rossi"
};


person.Id = personPersister.AddPerson(person);
person2.Id = personPersister.AddPerson(person2);

TeacherAdder(teacherPersister, person);
StudentAdder(studentPersister, person2);

printTeacher();
printStudent();

Console.ReadLine();


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
    var teacherRetriver = new TeacherRetriver();
    var teacherList = teacherRetriver.GetAllTeachers().ToList<Teacher>();
    foreach (var t in teacherList)
    {
        Console.WriteLine(t);
    }
}

static void printStudent()
{
    var studentRetriver = new StudentRetriver();
    var studList = studentRetriver.GetAllStudent().ToList<Student>();
    foreach (var s in studList)
    {
        Console.WriteLine(s);
    }
}