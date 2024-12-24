using Porfolio.Model;
using System.ComponentModel.DataAnnotations;

namespace Porfolio.Dto
{
    public class BlogDto
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Heading { get; set; }
        public string? Slug { get; set; }
        public string? MetaTitle { get; set; }
        public List<string>? MetaDescription { get; set; }
        [Required]
        public List<BlogContentDto>? BlogContent { get; set; }
        public List<ContentPhotoDto>? ContentPhotos { get; set; }
    }
}
