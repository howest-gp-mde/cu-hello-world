using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorld.Api.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public int? SerialNumberLength { get; set; }

        public List<Item> Items { get; set; }
    }
}
