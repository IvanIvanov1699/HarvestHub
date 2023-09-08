using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDBContext _context;

        public ItemRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateItemAsync(ItemDTO dto)
        {
            var newItem = new Item()
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                ImgSrc = dto.ImgSrc,
                Region = dto.Region,
                Price = dto.Price,
            };

            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(long id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> UpdateItemAsync(long id, ItemDTO dto)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item is null)
            {
                return false; // Item not found
            }

            item.Title = dto.Title;
            item.Description = dto.Description;
            item.Category = dto.Category;
            item.Region = dto.Region;
            item.Price = dto.Price;

            await _context.SaveChangesAsync();
            return true; // Item updated successfully
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item is null)
            {
                return false; // Item not found
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true; // Item deleted successfully
        }
    }
}