using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Model;
using Porfolio.Repositories.Interface;

namespace Porfolio.Repositories
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly PortfolioContext _context;

        public CustomerReviewRepository(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null.");
            }

            try
            {
                _context.CustomerReviews.Add(review);
                await _context.SaveChangesAsync();
                return review;
            }
            catch (Exception e)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error occurred while saving CustomerReview: {e.Message}");

                // Rethrow the exception to be handled by a higher layer
                throw new InvalidOperationException("Failed to create the customer review.", e);
            }
        }


        public async Task<IEnumerable<CustomerReview>> GetAllCustomerReviewsAsync()
        {
            return await _context.CustomerReviews
                .Include(cr => cr.FileDetails)
                .ToListAsync();
        }

        public async Task<CustomerReview?> GetCustomerReviewByIdAsync(int id)
        {
            return await _context.CustomerReviews
                .Include(cr => cr.FileDetails)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task<CustomerReview?> UpdateCustomerReviewAsync(int id, CustomerReview review)
        {
            var existingReview = await _context.CustomerReviews.FindAsync(id);
            if (existingReview == null)
                return null;

            existingReview.Email = review.Email;
            existingReview.ReviewDescription = review.ReviewDescription;
            existingReview.ReviewTime = review.ReviewTime;
            existingReview.Name = review.Name;
            existingReview.Quotation = review.Quotation;
            existingReview.Designation = review.Designation;
            existingReview.Address = review.Address;

            // Update FileDetails if provided
            if (review.FileDetails != null)
            {
                existingReview.FileDetails.FileName = review.FileDetails.FileName;
                existingReview.FileDetails.ContentType = review.FileDetails.ContentType;
                existingReview.FileDetails.Path = review.FileDetails.Path;
                existingReview.FileDetails.Data = review.FileDetails.Data;
            }

            await _context.SaveChangesAsync();
            return existingReview;
        }

        public async Task<bool> DeleteCustomerReviewAsync(int id)
        {
            var review = await _context.CustomerReviews.FindAsync(id);
            if (review == null)
                return false;

            _context.CustomerReviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
