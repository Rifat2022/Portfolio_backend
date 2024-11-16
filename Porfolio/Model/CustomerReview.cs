using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime ReviewTime { get; set; }

        public string? Photo { get; set; }
        public string? Name { get; set; }
        public string? Quotation { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
    }
}
