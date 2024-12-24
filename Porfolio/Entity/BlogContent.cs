using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class BlogContent
    {
        [Key]
        public int Id { get; set; }
        public int SerialNo { get; set; }  // Added SerialNo
        public string Content { get; set; }
        public string UniqueId { get; set; }


        // Foreign Key for Blog (One-to-One)
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
