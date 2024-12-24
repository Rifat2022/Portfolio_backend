using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class ContentPhoto
    {
        [Key]
        public int Id { get; set; }
        public string SerialNo { get; set; } = "";
        public string UniqueId { get; set; } = "";
        public BlogFileDetails? BlogFileDetails { get; set; } = null; 
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
