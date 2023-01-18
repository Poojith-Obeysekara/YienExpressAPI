using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.DTO
{
    public class UserCreateDTO
    {
        [Required]
        public string? userType { get; set; }
        [Required]
        public string? userName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? cPassword { get; set; }
    }
}
