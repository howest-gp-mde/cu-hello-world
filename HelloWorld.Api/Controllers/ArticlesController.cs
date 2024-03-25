using HelloWorld.Api.DTO;
using HelloWorld.Api.DTO.Response;
using HelloWorld.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleRepository.GetArticlesAsync();
            return Ok(new ResponseDTO<ArticleDTO>
            {
                Count = articles.Count,
                Results = articles
                .Select(a =>
                new ArticleDTO { Id = a.Id, Name = a.Name, Description = a.Description, ImageUrl = a.ImageUrl }
                ).ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null )
            {
                return BadRequest();
            }

            var article = await _articleRepository.GetArticleAsync(id.Value);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var article = _articleRepository.GetArticleAsync(id.Value);

            if(article is null)
            {
                return NotFound();
            }
            
            await _articleRepository.DeleteArticleAsync(article.Id);
            return Ok();
        }



    }
}
