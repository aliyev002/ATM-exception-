namespace ATM_class.EX2
{
    internal class WrongTypeException : Exception
    {
        public string Message { get; set; }

        public WrongTypeException(string message) : base(message)
        {
            Message = message;
        }
    }
}
