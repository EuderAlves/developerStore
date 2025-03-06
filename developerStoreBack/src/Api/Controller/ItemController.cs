using Microsoft.AspNetCore.Mvc;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Api.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            var item = await _itemService.AddItem(itemDto);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ItensAllDto>>> GetAllItems()
        {
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemById(string id)
        {
            var item = await _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(string id, [FromBody] ItemDto itemDto)
        {
            await _itemService.UpdateItem(id, itemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await _itemService.DeleteItem(id);
            return NoContent();
        }
    }
}