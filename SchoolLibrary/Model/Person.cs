namespace SchoolLibrary.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public override string? ToString()
        {
            return $"ID:{Id:D3} Name:{Name} Surname:{Surname} BirthDay:{BirthDay:d} Gender:{Gender} Adress:{Address}";
        }
    }
}
