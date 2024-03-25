namespace HelloWorld.Api.DTO.Response
{
    public class ResponseDTO<T> where T: IResponseDTO
    {
        public int Count { get; set; }

        public List<T> Results { get; set; }
    }
}
