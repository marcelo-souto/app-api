using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.DTO;
using app.Models;

namespace app.Mappers
{
    public static class SaleTypeMappers
    {

        public static SaleTypeDTO ToDTO(this SaleType saleType)
        {
            var dto = new SaleTypeDTO
            {
                Id = saleType.Id,
                Name = saleType.Name,
            };

            return dto;
        }

    }
}