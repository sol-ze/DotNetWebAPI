using Microsoft.AspNetCore.Mvc;
using UsersAPI.Dtos;
using UsersAPI.Repositories;

namespace UsersAPI.Controllers
{

    //GET /users
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = repository.GetUsers().Select(user => user.AsDto());
            return users;
        }


        [HttpPost("createOTP")]
        public async Task<IActionResult> SendOTP([FromBody] UserOTP userOtp)
        {
            try
            {
                if (userOtp is null || userOtp.Email is null)
                    return StatusCode(400, new { Status = "Email cannot be null" });

                if (userOtp.Email == "")
                    return StatusCode(400, new { Status = "Email cannot be empty" });

                await repository.SendOTP(userOtp);
                return Ok(new { Status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = "fail", message = ex.Message });
            }
        }
    }

}