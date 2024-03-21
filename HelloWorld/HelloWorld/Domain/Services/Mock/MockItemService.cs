using HelloWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services.Mock
{
    public class MockItemService : IItemService
    {
        private static List<Item> _items;
        public MockItemService()
        {
            if(_items == null)
            {
                _items = new List<Item>
                   {
                       new Item { Id = 1, SerialNumber = "SN-0001", Article = new Article { Name = "Printer", ImageUrl = "https://www.paradigit.nl/media/1965/inkjetprinter.jpg?width=353&height=279" }, IsAvailable = true, State = ItemState.New },
                       new Item { Id = 2, SerialNumber = "SN-0002", Article = new Article { Name = "Computer Screen", ImageUrl = "https://www.shareicon.net/data/2015/10/28/142191_display_256x256.png" }, IsAvailable = true, State = ItemState.New },
                       new Item { Id = 3, SerialNumber = "SN-0003", Article = new Article { Name = "Laptop", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State = ItemState.New },
                       new Item { Id = 4, SerialNumber = "SN-0004", Article = new Article { Name = "Keyboard", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State = ItemState.Broken },
                       new Item { Id = 5, SerialNumber = "SN-0005", Article = new Article { Name = "Mouse", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State = ItemState.Used },
                       new Item { Id = 6, SerialNumber = "SN-0006", Article = new Article { Name = "Headphones", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State = ItemState.Damaged },
                       new Item { Id = 7, SerialNumber = "SN-0007", Article = new Article { Name = "Microphone", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true , State = ItemState.New},
                       new Item { Id = 8, SerialNumber = "SN-0008", Article = new Article { Name = "Webcam", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State = ItemState.Used },
                       new Item { Id = 9, SerialNumber = "SN-0009", Article = new Article { Name = "USB Drive", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State= ItemState.Used },
                       new Item { Id = 10, SerialNumber = "SN-0010", Article = new Article { Name = "External Hard Drive", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" }, IsAvailable = true, State = ItemState.Used }
                   };
            }
        }

        public async Task<Item> GetItemAsync(int id)
        {
            await Task.Delay(500);

            return await Task.FromResult(_items.FirstOrDefault(i => i.Id == id));
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            await Task.Delay(500);

            return await Task.FromResult(_items);
        }

        public async Task SaveItemAsync(Item item)
        {
            await Task.Delay(500);

            var existingItem = _items.Where(p=>p.Id == item.Id).FirstOrDefault();
            
            existingItem.SerialNumber = item.SerialNumber;
            existingItem.Article = item.Article;
            existingItem.IsAvailable = item.IsAvailable;

        }
    }
}
