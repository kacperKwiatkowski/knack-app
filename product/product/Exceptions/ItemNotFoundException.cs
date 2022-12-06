namespace product.Exceptions;

public class ItemNotFoundException<T> : Exception
{
    public ItemNotFoundException(string message) : base(message)
    {
    }
}