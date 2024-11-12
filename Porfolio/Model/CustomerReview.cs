using System.ComponentModel.DataAnnotations;

namespace Porfolio.Model
{
    public class CustomerReview
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
