using System.Collections.Generic;

namespace HelloWorld.DTO.HelloWorldApi
{
    public class ResponseDTO<T>
    {
        public int Count { get; set; }

        public List<T> Results { get; set; }
    }
}
