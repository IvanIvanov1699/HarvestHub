using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;

namespace HarvestHub.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDBContext _context;

        public PurchaseRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(PurchaseDTO dto)
        {
            var newOrder = new Order()
            {
                OrderFull = dto.OrderFull,
                AddressFull = dto.AddressFull,
                AddressExtraInfo = dto.AddressExtraInfo,
                RecipientFullName = dto.RecipientFullName,
                RecipientPhoneNumber = dto.RecipientPhoneNumber,
                RecipientEmail = dto.RecipientEmail,
                PaymentMethod = dto.PaymentMethod,
                Status = dto.Status,
                Price = dto.Price,
                UserName = dto.UserName,
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }
    }
}
