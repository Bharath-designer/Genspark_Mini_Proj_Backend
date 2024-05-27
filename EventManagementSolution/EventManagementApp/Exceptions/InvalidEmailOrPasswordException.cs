namespace EventManagementApp.Exceptions
{
    public class InvalidEmailOrPasswordException:Exception
    {
        public InvalidEmailOrPasswordException(): base("Invalid Email or Password") { }
    }
}
