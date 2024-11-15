using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.DTO
{
    public class SaleItemDTO
    {
        public string Id { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public ProductDTO? Product { get; set; }
        public SaleDTO? Sale { get; set; }
    }
}