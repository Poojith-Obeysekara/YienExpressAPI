using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.Model
{
    public class Package
    {
        [Key]
        [Required]
       public int ID { get; set; }

        [Required]
       public string ?Name { get; set; }
       public decimal Price { get; set; }
       public int Stock { get; set; }
       public int ReorderLevel { get; set; }
       public string ?Category { get; set; }
    }
}
