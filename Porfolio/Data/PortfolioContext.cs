using Microsoft.EntityFrameworkCore;
using Porfolio.Model;

namespace Porfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }
        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerReview>()
                .HasOne(cr => cr.FileDetails)
                .WithOne()
                .HasForeignKey<CustomerReview>(cr => cr.FileDetailsId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete enabled
        }
    }
    

}
