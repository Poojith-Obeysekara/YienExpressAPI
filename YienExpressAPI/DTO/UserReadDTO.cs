using System.ComponentModel.DataAnnotations;

namespace YienExpressAPI.DTO
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        
        public string? userType { get; set; }
       
        public string? userName { get; set; }
        
        public string? Password { get; set; }
        public string? cPassword { get; set; }
    }
}
