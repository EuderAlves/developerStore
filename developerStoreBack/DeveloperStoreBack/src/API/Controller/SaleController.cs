using Microsoft.AspNetCore.Mvc;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using System.Collections.Generic;
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

        [HttpGet("customer/{email}")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByCustomerEmail(string email)
        {
            var sales = await _saleService.GetSalesByCustomerEmail(email);
            return Ok(sales);
        }
    }
}