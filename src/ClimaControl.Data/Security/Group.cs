using System.Collections.Generic;

namespace ClimaControl.Data.Security
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<User> Users { get; set; }
    }
}