using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class BlogContent
    {
        [Key]
        public int Id { get; set; }
        public int? SerialNo { get; set; } = null; 
        public string? Content { get; set; } = string.Empty;
        public string? UniqueId { get; set; }= string.Empty;
        public int BlogId { get; set; }
        public Blog? Blog { get; set; } = null;
    }
}
