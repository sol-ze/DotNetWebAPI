using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models
{
    public record User
    {
        public int Id { get; init; }

        public required String Name { get; set; }

        public required String Email { get; set; }

        [Column("is_verified")]
        public int IsVerified { get; set; }

        [Column("creation_date")]
        public DateTimeOffset CreationDate { get; init; }
    }
}