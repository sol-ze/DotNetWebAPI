using UsersAPI.Models;
using System.Collections.Generic;

namespace UsersAPI.Repositories {

    public class InMemUsersRepository {
        private readonly List<User> users = new() {
            new User {Id = Guid.NewGuid(), Name = "Sol", Email ="sol@gmail.com", IsVerified = 0, CreationDate = DateTimeOffset.UtcNow},
            new User {Id = Guid.NewGuid(), Name = "Adam", Email ="adam@gmail.com", IsVerified = 0, CreationDate = DateTimeOffset.UtcNow},
            new User {Id = Guid.NewGuid(), Name = "Dan", Email ="dan@gmail.com", IsVerified = 0, CreationDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<User> GetUsers() {
            return users;
        }

        public User GetUser(Guid id) {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

    }

}