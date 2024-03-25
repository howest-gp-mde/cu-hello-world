namespace HelloWorld.Api.DTO.Request
{
    public class ItemUpdateRequestDTO
    {
        public string SerialNumber { get; set; }

        public ArticleDTO Article { get; set; }
    }
}
