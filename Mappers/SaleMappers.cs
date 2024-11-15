using app.DTO;
using app.Models;

namespace app.Mappers
{
    public static class SaleMappers
    {
        public static SaleDTO ToDTO(this Sale sale)
        {
            var dto = new SaleDTO
            {
                Id = sale.Id,
                Date = sale.Date,
                Total = sale.Total,

            };

            if (sale.Items != null)
            {
                dto.Items = sale.Items.Select(i => i.ToDTO()).ToList();
            }

            if (sale.Customer != null)
            {
                dto.Customer = sale.Customer.ToDTO();
            }

            if (sale.SaleType != null)
            {
                dto.SaleType = sale.SaleType.ToDTO();
            }

            return dto;
        }
    }
}