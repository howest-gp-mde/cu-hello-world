using HelloWorld.Api.DTO.Response;

namespace HelloWorld.Api.DTO
{
    public class ItemDTO: IResponseDTO
    { 
        public int Id { get; set; }
        public string SerialNumber { get; set; }

        public ArticleDTO Article { get; set; }

    }
}
