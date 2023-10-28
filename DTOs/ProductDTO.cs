namespace Base64rontTest.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImageId { get; set; } = string.Empty;
    }
}
