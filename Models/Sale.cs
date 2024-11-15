using System.Text.Json.Serialization;

namespace app.Models
{
    public class Sale
    {
        public string Id { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public string SaleTypeId { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; } = 0;
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public Customer? Customer { get; set; }
        public SaleType? SaleType { get; set; }
    }
}