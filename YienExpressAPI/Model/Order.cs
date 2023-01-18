using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.Model
{
    public class Order
    {
        //[Key]
        //[Required]
        //public int Id { get; set; }
        //public string? Description { get; set; }
        //public DateTime Date { get; set; }
        //public List<Package> ?OrderItems { get; set; }
        //public List<Customer>?CustomerNames { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ?packageName { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public string ?customerName { get; set; }
        [Required]
        public string ?customerTel { get; set; }
        public String ?DateOfOrder { get; set; }
        [Required]

        public String? DateOfDelivery { get; set; }
        

        public string ?Description { get; set; }

        [Required]
        public string ?deliveryLocation { get; set; }

       
        public string ?trackStatus { get; set; }

    }
}
