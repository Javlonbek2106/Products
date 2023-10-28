using System.ComponentModel.DataAnnotations;

namespace Base64rontTest.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImageId { get; set; }
    }
}
