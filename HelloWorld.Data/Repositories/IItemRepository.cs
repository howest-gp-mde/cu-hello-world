using HelloWorld.Api.Entities;

namespace HelloWorld.Data.Repositories
{
    public interface IItemRepository
    {
        Task<int> CreateItemAsync(Item item);
        Task DeleteItemAsync(int itemId);
        Task<Item> GetItemAsync(int id);
        Task<List<Item>> GetItemsAsync();
        Task UpdateItemAsync(Item item);
    }
}