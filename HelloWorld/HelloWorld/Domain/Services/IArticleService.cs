using HelloWorld.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesAsync();
    }
}