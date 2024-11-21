using Microsoft.EntityFrameworkCore;

namespace Porfolio.Model
{
    
    public class FileDetails
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
    }
}
