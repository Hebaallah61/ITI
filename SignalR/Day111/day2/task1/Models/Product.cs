namespace task1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int quentity { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

    }
}
