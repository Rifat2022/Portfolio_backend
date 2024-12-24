using Porfolio.Entity;

namespace Porfolio.Dto
{
    public class ContentPhotoDto
    {
        public int? Id { get; set; }
        public string? SerialNo { get; set; } = "";
        public string? UniqueId { get; set; } = "";

        public BlogFileDetailsDto? BlogFileDetails { get; set; } = null;
    }
}
