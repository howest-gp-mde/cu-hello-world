namespace HelloWorld.Domain.Models
{
    public class Article
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if(obj is Article anotherArticle)
            {
                return anotherArticle.Name == this.Name;
            }
            return base.Equals(obj);
        }
    }
}