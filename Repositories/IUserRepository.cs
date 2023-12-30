using Microsoft.AspNetCore.Mvc;
using UsersAPI.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Repositories
{
    public interface IUsersRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();

        public Task<string> SendOTP(UserOTP userOtp);

        //void CreateUser(User user);
    }
}