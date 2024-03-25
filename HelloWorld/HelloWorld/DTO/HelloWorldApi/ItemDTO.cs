using HelloWorld.DTO.HelloWorldApi;

namespace HelloWorld.DTO.HelloWorldApi
{
    public class ItemDTO
    { 
        public int Id { get; set; }
        public string SerialNumber { get; set; }

        public ArticleDTO Article { get; set; }

    }
}
