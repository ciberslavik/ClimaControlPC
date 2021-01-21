using System.Linq;
using ClimaControl.Data.Security;
using ClimaControl.UI.Services;

namespace ClimaControl.Security
{
    public class ClimaSecurityService:ISecurityService
    {
        private readonly ISecurityRepository _repo;

        public ClimaSecurityService(ISecurityRepository repo)
        {
            _repo = repo;
        }
        public User CreateUser(string login, string passwordHash)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string login)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateUser(User user)
        {
            var dbUser = _repo.GetUsers().FirstOrDefault((o) => o.Login == user.Login);
            bool retValue = false;
            if (dbUser != null)
            {
                if (dbUser.PasswordHash.Equals(user.PasswordHash))
                    retValue = true;
            }

            return retValue;
        }
    }
}