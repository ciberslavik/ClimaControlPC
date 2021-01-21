using ClimaControl.Data.Security;

namespace ClimaControl.UI.Services
{
    public interface ISecurityService
    {
        User CreateUser(string login, string passwordHash);
        User GetUser(string login);
        bool ValidateUser(User user);
    }
}