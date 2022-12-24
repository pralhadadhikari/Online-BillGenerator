using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace BillGenerator.ViewModel
{
    public class BillViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }    

        public paymentType PaymentType { get; set; }
        public Item ItemId { get; set; }
        [Required]
        public List<SelectListItem> ItemList { get; set; }

        public decimal ItemPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
