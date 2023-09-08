using HarvestHub.DTOs;
using HarvestHub.Entities;

namespace HarvestHub.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Order> CreateOrderAsync(PurchaseDTO dto);

    }
}
