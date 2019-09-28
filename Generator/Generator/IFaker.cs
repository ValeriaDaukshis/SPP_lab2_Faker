namespace Generator
{
    public interface IFaker
    {
        T Create<T>();
    }
}