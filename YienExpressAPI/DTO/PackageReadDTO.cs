using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.DTO
{
    public class PackageReadDTO
    {
        public int ID { get; set; }
        public string ?Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ReorderLevel { get; set; }
        public string? Category { get; set; }

    }
}
