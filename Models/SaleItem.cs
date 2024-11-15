namespace app.Models
{
    public class SaleItem
    {
        public string Id { get; set; } = string.Empty;
        public string SaleId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public Product? Product { get; set; }
        public Sale? Sale { get; set; }
    }
}