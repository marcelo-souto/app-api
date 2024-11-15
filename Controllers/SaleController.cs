using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        SaleService _saleService;
        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var sales = await _saleService.GetAll();
            return Ok(sales);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(string id)
        {
            var sale = await _saleService.GetById(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleDTO createSaleDTO)
        {
            var sale = await _saleService.Create(createSaleDTO);
            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }


    }
}