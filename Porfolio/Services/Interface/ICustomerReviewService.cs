using Porfolio.Model;

namespace Porfolio.Services.Interface
{
    public interface ICustomerReviewService
    {
        Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review);
        Task<IEnumerable<CustomerReview>> GetAllCustomerReviewsAsync();
        Task<CustomerReview?> GetCustomerReviewByIdAsync(int id);
        Task<CustomerReview?> UpdateCustomerReviewAsync(int id, CustomerReview review);
        Task<bool> DeleteCustomerReviewAsync(int id);
    }
}
