namespace HelloWorld.Domain.Models
{
    public enum ItemState 
    {
        New, Used, Damaged, Broken
    }

    public class Item
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public Article Article { get; set; }
        public bool IsAvailable { get; set; }

        public ItemState State { get; set; }

        public string Location { get; set;  }

        //public override string ToString()
        //{
        //    return Article.Name + ": " + SerialNumber;
        //}
    }
}