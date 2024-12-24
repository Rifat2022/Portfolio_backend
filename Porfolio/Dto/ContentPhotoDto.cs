namespace Porfolio.Dto
{
    public class ContentPhotoDto
    {
        public int Serial { get; set; }
        public string UniqueId { get; set; }
        public IFormFile? File { get; set; }
    }
}
