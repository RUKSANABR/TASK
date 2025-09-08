using System.ComponentModel.DataAnnotations; //use validation attributes (like [Required], [StringLength], etc.) to add rules for your model properties.

namespace ProductDb.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
