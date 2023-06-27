namespace IM.Domain.Inventory.Exceptions;

public class InvalidProductException : Exception
{
    public InvalidProductException(string message) : base(message)
    {

    }
}

