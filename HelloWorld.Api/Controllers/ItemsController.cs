using HelloWorld.Api.DTO;
using HelloWorld.Api.DTO.Request;
using HelloWorld.Api.DTO.Response;
using HelloWorld.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        readonly IItemRepository _itemRepository;
        readonly IArticleRepository _articleRepository;

        public ItemsController(IItemRepository itemRepository, IArticleRepository articleRepository)
        {
            _itemRepository = itemRepository;
            _articleRepository = articleRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var items = await _itemRepository.GetItemsAsync();
            return Ok(new ResponseDTO<ItemDTO>
            {
                Count = items.Count,
                Results = items.Select(i =>
                    new ItemDTO
                    {
                        Article = new ArticleDTO
                        {
                            Id = i.Article.Id,
                            Description = i.Article.Description,
                            ImageUrl = i.Article.ImageUrl,
                            Name = i.Article.Name
                        },
                        Id = i.Id,
                        SerialNumber = i.SerialNumber
                    }
                ).ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var item = await _itemRepository.GetItemAsync(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] ItemCreateRequestDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            int id = await _itemRepository.CreateItemAsync(new Entities.Item
            {
                ArticleId = item.ArticleId,
                Article = await _articleRepository.GetArticleAsync(item.ArticleId),
                CreatedAt = DateTime.Now,
                SerialNumber = item.SerialNumber,
            }) ;

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var item = await _itemRepository.GetItemAsync(id.Value);

            if(id is null)
            {
                return NotFound();
            }
            
            await _itemRepository.DeleteItemAsync(item.Id);

            return Ok();
        }



    }
}
