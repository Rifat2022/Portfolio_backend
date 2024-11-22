using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Porfolio.Model
{

    public class FileDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileDetailsId { get; set; } // Primary key
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
        public byte[] Data { get; set; }
    }

}
