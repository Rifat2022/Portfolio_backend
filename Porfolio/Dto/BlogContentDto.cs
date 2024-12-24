using System.ComponentModel.DataAnnotations;

namespace Porfolio.Dto
{
    public class BlogContentDto
    {
        public int? Id { get; set; }
        public int? SerialNo { get; set; }
        public string? Content { get; set; }
        public string? UniqueId { get; set; }
    }
}
