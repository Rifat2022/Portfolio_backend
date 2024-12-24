using Microsoft.EntityFrameworkCore;
using Porfolio.Entity;
using Porfolio.Model;

namespace Porfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {

        }
        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<OfferedService> OfferedServices { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogFileDetails> BlogFileDetails { get; set; }
        public DbSet<BlogContent> BlogContents { get; set; }
        public DbSet<ContentPhoto> ContentPhotos { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<CoverPhoto> CoverPhotos { get; set; }
        public DbSet<BlogVideo> BlogVideos { get; set; }

        // Configure model relationships in OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerReview>()
                .HasOne(cr => cr.FileDetails)
                .WithOne()
                .HasForeignKey<CustomerReview>(cr => cr.FileDetailsId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete enabled

            // Many-to-Many relationship between Blog and Category via BlogCategory
            modelBuilder.Entity<BlogCategory>()
                .HasKey(bc => new { bc.BlogId, bc.CategoryId });

            modelBuilder.Entity<BlogCategory>()
                .HasOne(bc => bc.Blog)
                .WithMany(b => b.BlogCategories) // Blog has many BlogCategories
                .HasForeignKey(bc => bc.BlogId);

            modelBuilder.Entity<BlogCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BlogCategories) // Category has many BlogCategories
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<Blog>()
                .HasOne(bc => bc.CoverPhoto)
                .WithOne(b=> b.Blog)
                .HasForeignKey<CoverPhoto>(cp => cp.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.BlogVideo)
                .WithOne(bv => bv.Blog)
                .HasForeignKey<BlogVideo>(bv => bv.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.BlogContents)
                .WithOne(bv => bv.Blog)
                .HasForeignKey(bc => bc.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Blog>()
               .HasMany(b => b.ContentPhotos)
               .WithOne(bv => bv.Blog)
               .HasForeignKey(bc => bc.BlogId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Blog>()
               .HasMany(b => b.Comments)
               .WithOne(bv => bv.Blog)
               .HasForeignKey(bc => bc.BlogId)
               .OnDelete(DeleteBehavior.Cascade);
                        
            modelBuilder.Entity<ContentPhoto>()
                .HasOne(cp => cp.BlogFileDetails) // Navigation from ContentPhoto to BlogFileDetails
                .WithOne(bfd => bfd.ContentPhoto) // Navigation from BlogFileDetails to ContentPhoto
                .HasForeignKey<BlogFileDetails>(bfd => bfd.ContentPhotoId) // FK in BlogFileDetails
                .OnDelete(DeleteBehavior.Cascade);


        }
    }

}
