namespace Porfolio.Dto
{
    public class BlogVideoDto
    {
        public int? Id { get; set; } // Primary key
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? Path { get; set; }
        public byte[]? Data { get; set; }
    }
}
