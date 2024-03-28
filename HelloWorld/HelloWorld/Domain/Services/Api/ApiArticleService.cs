using HelloWorld.Domain.Models;
using HelloWorld.DTO.HelloWorldApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services.Api
{
    public class ApiArticleService : IArticleService
    {
        public ApiArticleService()
        {
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response =
                    await client
                    .GetFromJsonAsync<ResponseDTO<ArticleDTO>>(
                        Constants.BaseUrl + "/articles");

                return response.Results.Select(a =>
                new Article
                {
                    ImageUrl = a.ImageUrl,
                    Name = a.Name
                }).ToList();
            }

        }
    }
}
