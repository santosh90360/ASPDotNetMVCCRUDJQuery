using System.ComponentModel.DataAnnotations;

namespace ASPDotNetMVCCRUDJQuery.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
