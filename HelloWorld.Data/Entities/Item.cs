namespace HelloWorld.Api.Entities
{
    public enum ItemState
    {
        New, Used, Damaged, Broken
    }
    public class Item
    {
        public int Id { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public ItemState State { get; set; }
        public bool IsAvailable { get; set; }
        public string SerialNumber { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
