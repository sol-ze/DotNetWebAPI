using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Dtos
{
    public record UserOTP
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

    }

}