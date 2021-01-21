using System.Collections.Generic;
using ClimaControl.Data.Security;

namespace ClimaControl.Security
{
    public interface ISecurityRepository
    {
        User GetUserByLogin(string login);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void DeleteUser(string login);
        void UpdateUser(User user);


        Group GetGroupByName(string groupName);
        IEnumerable<Group> GetGroups();
        void AddGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(string groupName);
    }
}