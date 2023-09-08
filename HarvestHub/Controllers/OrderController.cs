using HarvestHub.Context;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("{UserName}")]
        public async Task<ActionResult<List<Order>>> GetOrderByUserName([FromRoute] string userName)
        {
            var orders = await _orderRepository.GetOrdersByUserNameAsync(userName);

            if (orders == null || !orders.Any())
            {
                return NotFound("Item not found!");
            }
            return Ok(orders);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrderById([FromRoute] long id)
        {
            var result = await _orderRepository.DeleteOrderAsync(id);

            if (!result)
            {
                return NotFound("Item not found!");
            }

            return Ok("Item deleted successfully!");
        }
    }
}
