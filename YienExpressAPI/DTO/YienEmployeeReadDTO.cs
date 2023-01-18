using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.DTO
{
    public class YienEmployeeReadDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
