using SchoolLibrary.Model;
using SchoolLibrary.Persister;
using SchoolLibrary.Modifier;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var persisterPerson = new PersonPersister();
var persisterTeacher = new TeacherPersister();

var person = new Person
{
    Address = "Largo Colombo",
    BirthDay = new DateTime(1975, 6, 30),
    Gender = "Male",
    Name = "Nicola",
    Surname = "Di Bari"
};


person.Id = persisterPerson.AddPerson(person);

var teacher = new Teacher
{
    Address = "Largo Colombo",
    BirthDay = new DateTime(1975, 6, 30),
    DataAssunzione = new DateTime(2001,01,05),
    Gender="Male",
    Id =person.Id,
    Name ="Nicola",
    Surname ="Di Bari",
    Matricola="ABDFDSF"
};

var idteacher = persisterTeacher.AddTeacher(teacher);

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

Console.WriteLine();