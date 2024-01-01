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
        public async Task<ActionResult> SendOTP([FromBody] UserOTP userOtp)
        {
            try
            {
                if (userOtp is null || userOtp.Email is null)
                {
                    return BadRequest(new ApiResponseDto { Status = "fail" });
                }

                if (!userOtp.Email.IsValidEmail())
                {
                    return BadRequest(new ApiResponseDto { Status = "fail" });
                }

                await repository.SendOTP(userOtp);

                return new OkObjectResult(new ApiResponseDto { Status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto { Status = "fail" });
            }
        }
    }

}