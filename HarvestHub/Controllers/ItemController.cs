using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItems([FromBody] ItemDTO dto)
        {
            var newItem = await _itemRepository.CreateItemAsync(dto);
            return Ok("Saved!");
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAllItems()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Item>> GetItemById([FromRoute] long id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound("Item not found!");
            }
            return Ok(item);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItemById([FromRoute] long id, [FromBody] ItemDTO dto)
        {
            var result = await _itemRepository.UpdateItemAsync(id, dto);

            if (!result)
            {
                return NotFound("Item not found!");
            }

            return Ok("Item updated successfully!");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItemById([FromRoute] long id)
        {
            var result = await _itemRepository.DeleteItemAsync(id);

            if (!result)
            {
                return NotFound("Item not found!");
            }

            return Ok("Item deleted successfully!");
        }
    }
}
