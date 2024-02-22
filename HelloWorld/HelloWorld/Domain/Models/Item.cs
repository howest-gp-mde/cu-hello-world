namespace HelloWorld.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public Article Article { get; set; }
        public bool IsAvailable { get; set; }

        //public override string ToString()
        //{
        //    return Article.Name + ": " + SerialNumber;
        //}
    }
}