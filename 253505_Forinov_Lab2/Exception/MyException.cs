namespace _253505_Forinov_Lab2.Exception;

public class MyException : System.Exception
{
    public MyException(string message)
        : base(message)
    {
        
    }

    public MyException(string message, System.Exception innerException)
        : base(message, innerException)
    {
        
    }
}