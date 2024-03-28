using HelloWorld.Api.Entities;

namespace HelloWorld.Data.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(int id);
        Task<int> CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int itemId);
    }
}