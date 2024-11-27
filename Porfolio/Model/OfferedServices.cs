using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Porfolio.Model
{
    public class OfferedService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferedServiceId { get; set; }
        public  string bootstrap_icon_code { get; set; }
        public  string description { get; set; }
        public  string headings { get; set; }
        public  string quote { get; set; }
        public  string? service_name { get; set; }
        public  string date { get; set; }
    }
}
