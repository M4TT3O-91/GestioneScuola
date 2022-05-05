namespace SchoolLibrary.Model
{
    public class Student : Person
    {
        public int IdStudent { get; set; }
        public string Matricola { get; set; }
        public DateTime DataIscrizione { get; set; }

        public override string? ToString()
        {
            return string.Concat(base.ToString(), $" - IdStudent:{IdStudent} Matricola:{Matricola} DataIscrizione:{DataIscrizione}");
        }
    }
}
