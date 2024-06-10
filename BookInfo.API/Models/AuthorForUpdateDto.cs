using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Models
{
    public class AuthorForUpdateDto
    {
        [Required(ErrorMessage = "You should provide an Id value.")]
        [MaxLength(11)]
        public string AuId { get; set; }

        [Required(ErrorMessage = "You should provide a Last Name value.")]
        [MaxLength(40)]
        public string AuLname { get; set; }

        [Required(ErrorMessage = "You should provide a First Name value.")]
        [MaxLength(20)]
        public string AuFname { get; set; }

        [Required(ErrorMessage = "You should provide a Phone Number value.")]
        [MaxLength(12)]
        public string? Phone { get; set; }

        [MaxLength(40)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? City { get; set; }

        [MaxLength(2)]
        public string? State { get; set; }

        [MaxLength(5)]
        public string? Zip { get; set; }

        [Required(ErrorMessage = "You should provide an Contract value.")]
        public string? Contract { get; set; }
    }
}
