using MyFirstNetCoreWebAPI.WebAPI.Data.Entities;
using MyFirstNetCoreWebAPI.WebAPI.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstNetCoreWebAPI.WebAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>()
        {
            new User("Andres"),
            new User("Julia"),
            new User("Manuel")
        };

        public ICollection<User> GetAll()
        {
            return _users;
        }

        public User Get(string name)
        {
            return _users.FirstOrDefault(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public bool Exists(string name)
        {
            return _users.Any(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
