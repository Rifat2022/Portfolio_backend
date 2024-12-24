using System.ComponentModel.DataAnnotations;

namespace Porfolio.Dto
{
    public class BlogContentDto
    {
        [Required]
        public int Serial { get; set; }
        [Required]
        public string UniqueId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
