namespace app.Models
{
    public class SaleType
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Sale>? Sales { get; set; }
    }
}