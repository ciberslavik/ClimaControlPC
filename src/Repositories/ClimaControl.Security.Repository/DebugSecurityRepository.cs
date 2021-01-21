using System.Collections.Generic;
using ClimaControl.Data.Security;

namespace ClimaControl.Security.Repository.Debug
{
    public class DebugSecurityRepository:ISecurityRepository
    {
        private Dictionary<string, User> _users;
        private Dictionary<string, Group> _groups;

        public DebugSecurityRepository()
        {
            _users = new Dictionary<string, User>();


            var usr = new User("engine", "!#/)zW??C?JJ??");
            _users.Add(usr.Login,usr);
            _groups = new Dictionary<string, Group>();
        }
        public User GetUserByLogin(string login)
        {
            return _users[login];
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.Values;
        }

        public void AddUser(User user)
        {
            _users.Add(user.Login,user);
        }

        public void DeleteUser(string login)
        {
            _users.Remove(login);
        }

        public void UpdateUser(User user)
        {
            _users[user.Login] = user;
        }

        public Group GetGroupByName(string groupName)
        {
            return _groups[groupName];
        }

        public IEnumerable<Group> GetGroups()
        {
            return _groups.Values;
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group.GroupName,group);
        }

        public void UpdateGroup(Group group)
        {
            _groups[group.GroupName] = group;
        }

        public void DeleteGroup(string groupName)
        {
            _groups.Remove(groupName);
        }
    }
}