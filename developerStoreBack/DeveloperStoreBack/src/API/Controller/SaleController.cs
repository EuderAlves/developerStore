using Microsoft.AspNetCore.Mvc;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Services;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SaleDto saleDto)
        {
            var sale = await _saleService.RegisterSale(saleDto);
            return CreatedAtAction(nameof(Register), new { id = sale.Id }, sale);
        }
    }
}