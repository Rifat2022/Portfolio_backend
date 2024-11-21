using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Interfaces;
using Porfolio.Model;
using Porfolio.UnitOfWork;
using Microsoft.Extensions.Logging;
using System.Text.Json;
namespace Porfolio.Services
{
    public class CustomerReviewService : ICustomerReviewService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerReviewRepository _customerReviewRepository;
        private readonly ILogger<CustomerReview> _logger;
        private readonly IFileService _fileService;

        public CustomerReviewService(ICustomerReviewRepository customerReviewRepository,
            IFileService fileService, ILogger<CustomerReview> logger)
        {
            _customerReviewRepository = customerReviewRepository;
            _fileService = fileService; 
            _logger = logger;
        }

        public async Task<List<CustomerReview>> GetAllReviewsAsync()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all customer reviews.");

                var reviews = await _customerReviewRepository.GetAllReviewsAsync();

                _logger.LogInformation("Successfully retrieved {Count} reviews.", reviews.Count);

                return reviews;
            }
            catch (Exception ex)
            {
                // Log the exception with context
                _logger.LogError(ex, "An error occurred while retrieving customer reviews.");

                // Optionally rethrow the exception or handle it as needed
                throw; // Re-throwing preserves the original stack trace
            }

        }

        public async Task<CustomerReview?> GetReviewByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve review with ID {Id}.", id);

                var review = await _customerReviewRepository.GetReviewByIdAsync(id);

                if (review == null)
                {
                    _logger.LogWarning("Review with ID {Id} not found.", id);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved review with ID {Id}.", id);
                }

                return review;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the review with ID {Id}.", id);
                throw; // Preserve the stack trace for higher-level handling
            }
        }


        public async Task<CustomerReview> CreateReviewAsync(CustomerReview review, IFormFile file)
        {
            
            if (file == null) throw new ArgumentNullException(nameof(file));
            try
            {
                _logger.LogInformation("Attempting to add a new file in the rootfolder");
                FileDetails fileDetails = await _fileService.UploadFileAsync(file, "customerReview");
                review.FileDetails = JsonSerializer.Serialize(fileDetails);
                _logger.LogInformation("Attempting to add a new review.");
                return await _customerReviewRepository.AddReviewAsync(review);                 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new review.");
                throw; // Rethrow to preserve stack trace.
            }
        }



        public async Task UpdateReviewAsync(CustomerReview review)
        {
            try
            {
                _logger.LogInformation("Attempting to update review with ID {Id}.", review.Id);

                await _customerReviewRepository.UpdateReviewAsync(review);

                _logger.LogInformation("Successfully updated review with ID {Id}.", review.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the review with ID {Id}.", review.Id);
                throw;
            }
        }


        public async Task DeleteReviewAsync(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to delete review with ID {Id}.", id);

                await _customerReviewRepository.DeleteReviewAsync(id);

                _logger.LogInformation("Successfully deleted review with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the review with ID {Id}.", id);
                throw;
            }
        }

    }

}
