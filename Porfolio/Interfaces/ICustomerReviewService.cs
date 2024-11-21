using Porfolio.Model;

namespace Porfolio.Interfaces
{
    public interface ICustomerReviewService
    {
        Task<List<CustomerReview>> GetAllReviewsAsync();
        Task<CustomerReview?> GetReviewByIdAsync(int id);
        Task<CustomerReview> CreateReviewAsync(CustomerReview review, IFormFile file);
        Task UpdateReviewAsync(CustomerReview review);
        Task DeleteReviewAsync(int id);

    }
}
