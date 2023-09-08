using HarvestHub.DTOs;
using HarvestHub.Entities;

namespace HarvestHub.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> CreateItemAsync(ItemDTO dto);
        Task<List<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(long id);
        Task<bool> UpdateItemAsync(long id, ItemDTO dto);
        Task<bool> DeleteItemAsync(long id);
    }
}
