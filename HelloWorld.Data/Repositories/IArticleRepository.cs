using HelloWorld.Api.Entities;

namespace HelloWorld.Data.Repositories
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetArticlesAsync();
        Task<Article> GetArticleAsync(int id);
        Task<int> CreateArticleASync(Article article);
        Task UpdateArticleAsync(int id, Article article);
        Task DeleteArticleAsync(int articleId);
    }
}