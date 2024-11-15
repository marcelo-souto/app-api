using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.DTO
{
    public class SaleDTO
    {
        public string Id { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; } = 0;
        public List<SaleItemDTO>? Items { get; set; }
        public CustomerDTO? Customer { get; set; }
        public SaleTypeDTO? SaleType { get; set; }
    }
}