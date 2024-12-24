using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

        // Foreign Key for BlogPost
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
