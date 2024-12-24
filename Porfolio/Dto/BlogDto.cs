using Porfolio.Entity;

namespace Porfolio.Dto
{
    public class BlogDto
    {
        public string? Title { get; set; }
        public int? Id { get; set; }
        public string? Heading { get; set; }
        public string? Slug { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? AuthorName { get; set; }
        public List<BlogContentDto>? BlogContent { get; set; }
        public List<ContentPhotoDto>? ContentPhotos { get; set; }
        public CoverPhoto? CoverPhoto{ get; set; }
        public BlogVideo? BlogVideo{ get; set; }
    }
}
