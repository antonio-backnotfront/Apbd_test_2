namespace Apbd_test_2.API.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string msg) : base(msg)
    {
        
    }
}