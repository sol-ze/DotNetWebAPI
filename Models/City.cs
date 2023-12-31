using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPI.Models
{
    public record City
    {
        public int Id { get; init; }
        [Column("city")]
        public string CityName { get; init; }

    }
}