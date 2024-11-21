using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Interfaces;
using Porfolio.Model;

namespace Porfolio.Repositories
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly PortfolioContext _context;

        public CustomerReviewRepository(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<List<CustomerReview>> GetAllReviewsAsync()
        {
            return await _context.CustomerReviews.ToListAsync();
        }

        public async Task<CustomerReview?> GetReviewByIdAsync(int id)
        {
            return await _context.CustomerReviews.FindAsync(id);
        }

        public async Task<CustomerReview> AddReviewAsync(CustomerReview review)
        {
            _context.CustomerReviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task UpdateReviewAsync(CustomerReview review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.CustomerReviews.FindAsync(id);
            if (review != null)
            {
                _context.CustomerReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
