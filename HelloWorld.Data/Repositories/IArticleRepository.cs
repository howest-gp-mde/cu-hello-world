using HelloWorld.Api.Entities;

namespace HelloWorld.Data.Repositories
{
    public interface IArticleRepository
    {
        Task DeleteArticleAsync(int articleId);
        Task<Article> GetArticleAsync(int id);
        Task<List<Article>> GetArticlesAsync();
        Task UpdateArticleAsync(Article article);
    }
}