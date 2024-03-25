using HelloWorld.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Data.Repositories
{
    public class MockArticleRepository : IArticleRepository
    {
        private static List<Article> _articles;
        public MockArticleRepository()
        {
            if (_articles is null)
            {
                _articles = new List<Article> {
                    new Article {Id =1, Name = "Webcam", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" },
                    new Article {Id =2, Name = "Mouse", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" },
                    new Article {Id =3, Name = "Laptop", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" },
                    new Article {Id =4, Name = "Headphones", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" },
                    new Article {Id =5, Name = "Keyboard", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" },
                    new Article {Id =6, Name = "Printer", ImageUrl = "https://www.paradigit.nl/media/1965/inkjetprinter.jpg?width=353&height=279" },
                    new Article {Id =7, Name = "Microphone", ImageUrl = "https://images.unsplash.com/photo-1626193050658-3a5b9d6f4f2c" },
                    new Article {Id =8, Name = "Computer Screen", ImageUrl = "https://www.shareicon.net/data/2015/10/28/142191_display_256x256.png" }
                };
            }
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            return await Task.FromResult<List<Article>>(_articles);
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await Task.FromResult<Article>(_articles.First(a => a.Id == id));
        }

        public async Task<int> CreateArticleAsync(Article article)
        {
            int id = _articles.Max(a => a.Id) + 1;
            article.Id = id;
            _articles.Add(article);
            await Task.Delay(200);
            return id;
        }
        public async Task UpdateArticleAsync(Article article)
        {

            await DeleteArticleAsync(article.Id);

            _articles.Add(article);

            await Task.Delay(200);
        }

        public async Task DeleteArticleAsync(int articleId)
        {
            var article = await GetArticleAsync(articleId);
            _articles.Remove(article);
            await Task.Delay(200);
        }
    }
}
