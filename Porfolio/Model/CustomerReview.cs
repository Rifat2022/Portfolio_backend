using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Porfolio.Model
{
    public class CustomerReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(300)]
        public string ReviewDescription { get; set; }
        public string? ReviewTime { get; set; }

        // Foreign key for FileDetails
        [Required]
        public int FileDetailsId { get; set; }
        public FileDetails FileDetails { get; set; } // Navigation property

        public string? Name { get; set; }
        public string? Quotation { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
    }

}
