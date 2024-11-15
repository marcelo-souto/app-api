using System.ComponentModel.DataAnnotations;
using app.DTO;
using app.Mappers;
using app.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    public class CustomerService
    {
        ApplicationDBContext _context;
        public CustomerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerDTO>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers.Select(c => c.ToDTO()).ToList();
        }

        public async Task<CustomerDTO> Create(CreateCustomerDTO createCustomerDTO)
        {
            var id = Guid.NewGuid().ToString();
            var newCustomer = new Customer
            {
                Id = id,
                Name = createCustomerDTO.Name,
                Address = createCustomerDTO.Address,
            };

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer.ToDTO();
        }

        public async Task<CustomerDTO?> Update(string id, UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null) return null;

            customer.Name = updateCustomerDTO.Name;
            customer.Address = updateCustomerDTO.Address;

            await _context.SaveChangesAsync();

            return customer.ToDTO();
        }

        public async Task<CustomerDTO?> GetById(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return null;
            return customer.ToDTO();
        }

        public async Task<Customer?> Delete(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return null;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
    }

    public class CreateCustomerDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }

    public class UpdateCustomerDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}