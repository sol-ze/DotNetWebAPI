using System.ComponentModel.DataAnnotations.Schema;

namespace Name
{
    [Table("user_verification_code")]
    public record UserVerificationCode
    {
        public int Id { get; init; }
        public required string Email { get; set; }

        public required String Code { get; set; }
        [Column("creation_time")]
        public required DateTimeOffset CreationTime { get; set; }


    }

}