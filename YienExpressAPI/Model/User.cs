using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.Model
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? userType { get; set; }
        [Required]
        public string ?userName { get; set; }
        [Required]
        public string ?Password { get; set; }
        public string? cPassword { get; set; }
    }
}
