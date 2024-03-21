using HelloWorld.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services
{
    public interface IItemService
    {
        Task<Item> GetItemAsync(int id);
        Task<List<Item>> GetItemsAsync();
        Task SaveItemAsync(Item item);
    }
}