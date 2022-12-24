namespace BillGenerator.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }    

        
    }
    public enum paymentType
    {
        cash,
        UPI
    }
}