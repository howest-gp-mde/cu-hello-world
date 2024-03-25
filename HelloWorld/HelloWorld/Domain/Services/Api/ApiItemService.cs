using HelloWorld.Domain.Models;
using HelloWorld.DTO.HelloWorldApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services.Api
{
    internal class ApiItemService: IItemService
    {
        const string BaseUrl = "https://localhost:7253";

        public Task<Item> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(BaseUrl + "/items");
                ResponseDTO<ItemDTO> itemResponse =
                    JsonConvert.DeserializeObject<ResponseDTO<ItemDTO>>(response);

                return itemResponse.Results
                    .Select(i => new Item
                    {
                        Id = i.Id,
                        Article = new Article { ImageUrl = i.Article.ImageUrl, Name = i.Article.Name },
                        IsAvailable = true,
                        SerialNumber = i.SerialNumber,
                    }).ToList();
            }
        }

        public Task SaveItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
