

using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BillGenerator.ViewModel
{
    public class ItemsViewModel
    {
       public Item Item { get; set; } = new Item();
        [ValidateNever]
       public IEnumerable<Item> items { get; set; } = new List<Item>();
        
    }
}

