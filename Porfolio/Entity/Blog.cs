using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Porfolio.Entity
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AuthorName { get; set; } = null!; 
        public string Title { get; set; } = null!;
        public string? Heading { get; set; }
        public string? Slug { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }

        public BlogVideo? BlogVideo { get; set; }
        public CoverPhoto? CoverPhoto { get; set; }

        public virtual ICollection<ContentPhoto>? ContentPhotos { get; set; }
        public virtual ICollection<BlogContent>? BlogContents { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<BlogCategory>? BlogCategories { get; set; } 
        public DateTime CreatedAt { get; set; }

    }









    //public class SerialIdentifier
    //{
    //    public int Id { get; set; }
    //    public string SerialNumber { get; set; }
    //    public string UniqueId { get; set; }

    //    // Foreign Key for Blog (One-to-One)
    //    public int BlogId { get; set; }
    //    public Blog Blog { get; set; }
    //}






}
