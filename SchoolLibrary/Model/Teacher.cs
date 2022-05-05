namespace SchoolLibrary.Model
{
    public class Teacher : Person
    {
        public int IdTeacher { get; set; }
        public string Matricola { get; set; }
        public DateTime DataAssunzione { get; set; }

        public override string? ToString()
        {
            return string.Concat(base.ToString(), $" - IdTeacher:{IdTeacher} Matricola:{Matricola} DataAssunzione:{DataAssunzione}");
        }
    } 
}
