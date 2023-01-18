using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.Model
{
    public class Customer
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
