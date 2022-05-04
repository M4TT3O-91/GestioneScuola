namespace SchoolLibrary.Interface
{
    public interface IRetriver<T>
    {
        IEnumerable<T> GetAll(int id);
    }
}
