namespace app.Models
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}