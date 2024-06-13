namespace ATM_class.Exceptions;

internal class İncorrectAmountException:Exception
{
    public  string Message { get; set; }

    public İncorrectAmountException(string message):base(message)
    {
        Message = message;
    }
}
