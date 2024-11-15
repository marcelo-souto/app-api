using System.Text.Json.Serialization;

namespace app.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public List<SaleItem> Sales { get; set; } = new List<SaleItem>();
    }
}