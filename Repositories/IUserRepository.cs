using Microsoft.AspNetCore.Mvc;
using UsersAPI.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();

        public Task<ApiResponseDto> SendOTP(UserOTP userOtp);
    }
}