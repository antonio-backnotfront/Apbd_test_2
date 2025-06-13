namespace AuthTest.API.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string msg) : base(msg)
    {
        
    }
}