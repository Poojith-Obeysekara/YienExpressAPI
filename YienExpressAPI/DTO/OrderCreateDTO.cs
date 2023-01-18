using System.ComponentModel.DataAnnotations;
using YienExpressAPI.Model;

namespace YienExpressAPI.DTO
{
    public class OrderCreateDTO
    {
        [Required]
        public string? packageName { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public string? customerName { get; set; }
        [Required]
        public string? customerTel { get; set; }
        public String? DateOfOrder { get; set; }
        [Required]

        public String? DateOfDelivery { get; set; }


        public string? Description { get; set; }

        [Required]
        public string? deliveryLocation { get; set; }


        public string? trackStatus { get; set; }

    }
}
