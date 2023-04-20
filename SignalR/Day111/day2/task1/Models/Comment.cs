using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string text { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public string Username { get; set; }
        public virtual Product Product { get; set; }
    }
}
