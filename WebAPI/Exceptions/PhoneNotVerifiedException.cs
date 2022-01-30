namespace WebAPI.Exceptions
{
    public class PhoneNotVerifiedException:Exception
    {
        public string Message { get; set; } 

        public PhoneNotVerifiedException(string message)
        {
            Message = message;
        }
    }
}
