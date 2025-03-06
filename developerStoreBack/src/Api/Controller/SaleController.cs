using Microsoft.AspNetCore.Mvc;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Services;
using DeveloperStoreBack.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Api.Controllers
{
    [ApiController]
    [Route("api/sale")]
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
            var saleReturnDto = await _saleService.RegisterSale(saleDto);
            return CreatedAtAction(nameof(Register), new { id = saleReturnDto.Id }, saleReturnDto); // Retorna o DTO com Id como string
        }

        [HttpGet("customer/{email}")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByCustomerEmail(string email)
        {
            var sales = await _saleService.GetSalesByCustomerEmail(email);
            return Ok(sales);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelSale(string id)
        {
            await _saleService.CancelSale(id);
            return NoContent();
        }

        [HttpPost("{saleId}/items/{productId}/cancel")]
        public async Task<IActionResult> CancelSaleItem(string saleId, string productId)
        {
            await _saleService.CancelSaleItem(saleId, productId);
            return NoContent();
        }

        [HttpPut("{saleId}/items")]
        public async Task<IActionResult> UpdateSaleItem(string saleId, [FromBody] SaleItemDto itemDto)
        {
            await _saleService.UpdateSaleItem(saleId, itemDto);
            return NoContent();
        }

        [HttpPost("{id}/finalize")]
        public async Task<IActionResult> FinalizeSale(string id)
        {
            await _saleService.FinalizeSale(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(string id)
        {
            await _saleService.DeleteSale(id);
            return NoContent();
        }
    }
}