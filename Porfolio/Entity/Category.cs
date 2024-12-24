using System.ComponentModel.DataAnnotations;

namespace Porfolio.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>();  // Added
    }
}
