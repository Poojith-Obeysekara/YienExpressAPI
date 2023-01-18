using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.DTO
{
    public class PackageCreateDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ReorderLevel { get; set; }
        public string? Category { get; set; }

    }
}
