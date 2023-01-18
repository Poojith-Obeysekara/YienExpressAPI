using System.ComponentModel.DataAnnotations;
using YienExpressAPI.Model;

namespace YienExpressAPI.DTO
{
    public class OrderReadDTO
    {
        public int Id { get; set; }
        
        public string? packageName { get; set; }
        
        public int quantity { get; set; }
        
        public string? customerName { get; set; }
       
        public string? customerTel { get; set; }
        public String? DateOfOrder { get; set; }
        

        public String? DateOfDelivery { get; set; }
        

        public string? Description { get; set; }

       
        public string? deliveryLocation { get; set; }

       
        public string? trackStatus { get; set; }

    }
}
