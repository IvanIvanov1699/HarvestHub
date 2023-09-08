using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] PurchaseDTO dto)
        {
            var newOrder = await _purchaseRepository.CreateOrderAsync(dto);
            return Ok("Order added successfully!");
        }
    }
}
