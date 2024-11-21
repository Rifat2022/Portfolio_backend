using Microsoft.EntityFrameworkCore;
using Porfolio.Model;

namespace Porfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }
        public DbSet<CustomerReview> CustomerReviews { get; set; }

    }

}
