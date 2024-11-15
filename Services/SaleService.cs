using System.ComponentModel.DataAnnotations;
using app.DTO;
using app.Mappers;
using app.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    public class SaleService
    {
        ApplicationDBContext _context;

        public SaleService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<SaleDTO> Create(CreateSaleDTO createSaleDTO)
        {
            Console.WriteLine("Creating sale");

            var products = await _context.Products
                                            .Where(p => createSaleDTO.Items.Select(i => i.Id).Contains(p.Id))
                                                .ToDictionaryAsync(product => product.Id, product => product.Price);

            Console.Write(products.ToString());

            var newSale = new Sale
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = createSaleDTO.CustomerId,
                SaleTypeId = createSaleDTO.SaleTypeId,
                Date = DateTime.UtcNow,
                Items = createSaleDTO.Items.Select(i => new SaleItem
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = i.Id,
                    Quantity = i.Quantity,
                    UnitPrice = products[i.Id],
                }).ToList(),
                Total = createSaleDTO.Items.Sum(i => i.Quantity * products[i.Id])
            };

            await _context.Sales.AddAsync(newSale);
            await _context.SaveChangesAsync();

            return newSale.ToDTO();
        }

        public async Task<List<SaleDTO>> GetAll()
        {
            var sales = await _context.Sales
                                        .Include(x => x.SaleType)
                                        .Include(x => x.Customer)
                                        .Include(s => s.Items)
                                            .ThenInclude(i => i.Product)
                                                .ToListAsync();

            return sales.Select(s => s.ToDTO()).ToList();
        }

        public async Task<SaleDTO?> GetById(string id)
        {
            var sale = await _context.Sales
                                        .Include(x => x.SaleType)
                                            .Include(s => s.Items)
                                                .ThenInclude(i => i.Product)
                                                    .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null) return null;
            return sale.ToDTO();
        }
    }

    public class CreateSaleDTO
    {
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string SaleTypeId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Sale must have at least one item.")]
        public List<CreateSaleItemDTO> Items { get; set; }
    }

    public class CreateSaleItemDTO
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
    }
}