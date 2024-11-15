using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.DTO;
using app.Models;

namespace app.Mappers
{
    public static class SaleItemMappers
    {
        public static SaleItemDTO ToDTO(this SaleItem saleItem)
        {
            var dto = new SaleItemDTO
            {
                Id = saleItem.Id,
                Quantity = saleItem.Quantity,
                UnitPrice = saleItem.UnitPrice
            };

            if (saleItem.Product != null)
            {
                dto.Product = saleItem.Product.ToDTO();
            }

            return dto;
        }
    }
}