namespace Springboard365.Xrm.Authentication
{
    public class UserCredentials
    {
        public UserCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }

        public string Password { get; private set; }
    }
}