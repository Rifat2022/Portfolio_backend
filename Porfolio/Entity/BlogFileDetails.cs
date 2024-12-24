using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class BlogFileDetails
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Data { get; set; }
        public string Path { get; set; }

        public int ContentPhotoId { get; set; }
        public ContentPhoto? ContentPhoto { get; set; }
    }
}
