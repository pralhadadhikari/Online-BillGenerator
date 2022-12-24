
using System.ComponentModel.DataAnnotations;

namespace BillGenerator.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public decimal Price { get; set; }

        
    }
}
