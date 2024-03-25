using HelloWorld.Domain.Models;
using HelloWorld.DTO.HelloWorldApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace HelloWorld.Domain.Services.Api
{
    public class ApiItemService: IItemService
    {

        public Task<Item> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            using (var client = new HttpClient())
            {

                var itemResponse = await client.GetFromJsonAsync<ResponseDTO<ItemDTO>>(Constants.BaseUrl + "/items");

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

        public async Task SaveItemAsync(Item item)
        {
            using(var client = new HttpClient()) {

                var response = await client.PostAsJsonAsync(Constants.BaseUrl + "/items", item);
            }
        }

       
    }
}
