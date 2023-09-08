using HarvestHub.Context;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;

        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserNameAsync(string userName)
        {
            return await _context.Orders
                .Where(i => i.UserName == userName)
                .ToListAsync();
        }

        public async Task<bool> DeleteOrderAsync(long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);

            if (order is null)
            {
                return false; // Order not found
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true; // Order deleted successfully
        }
    }
}
