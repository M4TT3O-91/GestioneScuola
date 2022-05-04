namespace SchoolLibrary.Interface
{
    public interface IRetriver<T>
    {
        IEnumerable<T> GetByID(int id);
    }
}
