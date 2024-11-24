
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
        private readonly IFileDetailsService _fileDetailsService;

        public CustomerReviewService (
            ICustomerReviewRepository customerReviewRepository,
            IFileService fileService,
            IFileDetailsService fileDetailsService,
            ILogger<CustomerReview> logger)
        {
            _customerReviewRepository = customerReviewRepository;
            _fileService = fileService; 
            _fileDetailsService = fileDetailsService;
            _logger = logger;
        }


        public async Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review, IFormFile file)
        {
            var fileDetails = await _fileDetailsService.GetFileDetailsFromFile(file);
            review.FileDetails = fileDetails;
            return await _customerReviewRepository.CreateCustomerReviewAsync(review);
        }

        public async Task<IEnumerable<CustomerReview>> GetAllCustomerReviewsAsync()
        {
            return await _customerReviewRepository.GetAllCustomerReviewsAsync();
        }

        public async Task<CustomerReview?> GetCustomerReviewByIdAsync(int id)
        {
            return await _customerReviewRepository.GetCustomerReviewByIdAsync(id);
        }

        public async Task<CustomerReview?> UpdateCustomerReviewAsync(int id, CustomerReview review)
        {
            return await _customerReviewRepository.UpdateCustomerReviewAsync(id, review);
        }

        public async Task<bool> DeleteCustomerReviewAsync(int id)
        {
            return await _customerReviewRepository.DeleteCustomerReviewAsync(id);
        }

    }

}
