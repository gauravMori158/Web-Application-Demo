using System.ComponentModel.DataAnnotations;

namespace WebdevelopmentDemo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; }  
    }
}
