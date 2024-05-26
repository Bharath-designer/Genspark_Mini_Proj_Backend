namespace EventManagementApp.Exceptions
{
    public class EmailAlreadyExistsException:Exception
    {
        public EmailAlreadyExistsException() : base("Email is already registered") { }
    }
}
