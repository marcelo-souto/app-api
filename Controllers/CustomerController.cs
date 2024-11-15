using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{

    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO createCostumerDTO)
        {
            var customer = await _customerService.Create(createCostumerDTO);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = await _customerService.Update(id, updateCustomerDTO);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var customer = await _customerService.Delete(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}