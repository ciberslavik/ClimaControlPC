namespace ClimaControl.Data.Security
{
    public class User
    {
        public User()
        {
            Login = "";
            PasswordHash = "";
            Profile=new UserProfile();
        }
        public User(string login,string passwordHash)
        {
            Login = login;
            PasswordHash = passwordHash;
            Profile = new UserProfile();
        }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public UserProfile Profile { get; set; }
    }
}