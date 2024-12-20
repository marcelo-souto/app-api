namespace app.DTO
{
    public class ProductDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public List<SaleItemDTO>? Sales { get; set; }
    }
}