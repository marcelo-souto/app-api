using System.ComponentModel.DataAnnotations;
using app.DTO;
using app.Mappers;
using app.Models;
using App.Data;
using App.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    public class ProductService
    {
        ApplicationDBContext _context;

        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(product => product.ToDTO()).ToList();
        }

        public async Task<ProductDTO> GetById(string id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null) throw new NotFoundException("Product not found.");

            return product.ToDTO();
        }

        public async Task<ProductDTO> Create(CreateProductDTO createProductDTO)
        {
            var existingProduct = await _context.Products
                                                .FirstOrDefaultAsync(product => product.Name == createProductDTO.Name);

            if (existingProduct != null) throw new ConflictException("Product already exists.");

            var newProduct = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = createProductDTO.Name,
                Price = createProductDTO.Price,
                Description = createProductDTO.Description,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.ToDTO();
        }

        public async Task<ProductDTO> Update(string id, UpdateProductDTO updateProductDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null) throw new NotFoundException("Product not found.");

            var existingProduct = await _context.Products
                                                .FirstOrDefaultAsync(product => product.Name == updateProductDTO.Name);

            if (existingProduct != null) throw new ConflictException("Product already exists.");

            if (updateProductDTO.Price < 0) throw new ValidationException("Price must be greater than 0.");

            product.Name = updateProductDTO.Name ?? product.Name;
            product.Price = updateProductDTO.Price ?? product.Price;
            product.Description = updateProductDTO.Description ?? product.Description;

            await _context.SaveChangesAsync();

            return product.ToDTO();
        }

    }

    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class UpdateProductDTO
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}