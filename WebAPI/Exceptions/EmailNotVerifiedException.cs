namespace WebAPI.Exceptions
{
    public class EmailNotVerifiedException : Exception
    {
        public string Message { get; set; } 

        public EmailNotVerifiedException(string message)
        {
            Message = message;
        }
    }
}
