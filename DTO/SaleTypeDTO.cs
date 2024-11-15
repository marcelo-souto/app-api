namespace app.DTO
{
    public class SaleTypeDTO
    {
        public string? Id { get; set; } 
        public string? Name { get; set; }
        public List<SaleDTO>? Sales { get; set; }
    }
}