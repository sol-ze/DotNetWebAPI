using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;
using UsersAPI.Repositories;

namespace UsersAPI.Controllers {

//GET /users
[ApiController]
[Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly InMemUsersRepository usersRepository;

        public UsersController() {
            usersRepository = new InMemUsersRepository();
        }
        [HttpGet]
        public IEnumerable<User> GetUsers() {
            var users = usersRepository.GetUsers();
            return users;
        }

        
    }
    
}