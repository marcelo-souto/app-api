using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.DTO;
using app.Models;

namespace app.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDTO ToDTO(this Customer customer)
        {
            var dto = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,

            };

            // if (customer.Sales != null)
            // {
            //     dto.Sales = customer.Sales.Select(s => s.ToDTO()).ToList();
            // }

            return dto;
        }
    }
}