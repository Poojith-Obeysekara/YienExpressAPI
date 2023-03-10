using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.DTO
{
    public class CoporateCustomerCreateDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? specialPlan { get; set; }
    }
}
