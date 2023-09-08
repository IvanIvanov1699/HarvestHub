using HarvestHub.Entities;

namespace HarvestHub.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByUserNameAsync(string userName);
        Task<bool> DeleteOrderAsync(long id);
    }
}
