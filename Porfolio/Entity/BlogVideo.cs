using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class BlogVideo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; } // Primary key
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? Path { get; set; }
        public byte[]? Data { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
