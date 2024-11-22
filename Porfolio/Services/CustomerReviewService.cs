
using Porfolio.Model;
using Porfolio.Repositories.Interface;
using Porfolio.Services.Interface;
namespace Porfolio.Services
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ILogger<CustomerReview> _logger;
        private readonly IFileService _fileService;
        private readonly ICustomerReviewRepository _customerReviewRepository;

        public CustomerReviewService (
            ICustomerReviewRepository customerReviewRepository,
            IFileService fileService, 
            ILogger<CustomerReview> logger)
        {
            _customerReviewRepository = customerReviewRepository;
            _fileService = fileService; 
            _logger = logger;
        }

        private readonly ICustomerReviewRepository _repository;

        public async Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review)
        {
            return await _repository.CreateCustomerReviewAsync(review);
        }

        public async Task<IEnumerable<CustomerReview>> GetAllCustomerReviewsAsync()
        {
            return await _repository.GetAllCustomerReviewsAsync();
        }

        public async Task<CustomerReview?> GetCustomerReviewByIdAsync(int id)
        {
            return await _repository.GetCustomerReviewByIdAsync(id);
        }

        public async Task<CustomerReview?> UpdateCustomerReviewAsync(int id, CustomerReview review)
        {
            return await _repository.UpdateCustomerReviewAsync(id, review);
        }

        public async Task<bool> DeleteCustomerReviewAsync(int id)
        {
            return await _repository.DeleteCustomerReviewAsync(id);
        }

    }

}
