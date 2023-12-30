using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Dtos
{
    public record UserDto
    {
        public int Id { get; init; }

        public required String Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required String Email { get; set; }

        public DateTimeOffset CreationDate { get; init; }
    }
}