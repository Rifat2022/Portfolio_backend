using Microsoft.EntityFrameworkCore;
using Porfolio.BusinessLogic;
using Porfolio.Data;
using Porfolio.Interfaces;
using Porfolio.Model;
using Porfolio.UnitOfWork;

namespace Porfolio.Services
{
    public class CustomerReviewService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerReview>> GetAllReviewsAsync()
        {
            return await _unitOfWork.CustomerReviewRepository.GetAllReviewsAsync();
        }

        public async Task<CustomerReview?> GetReviewByIdAsync(int id)
        {
            return await _unitOfWork.CustomerReviewRepository.GetReviewByIdAsync(id);
        }

        public async Task AddReviewAsync(CustomerReview review)
        {
            // Here you might perform other actions involving multiple repositories
            await _unitOfWork.CustomerReviewRepository.AddReviewAsync(review);

            // Commit the transaction by calling SaveChangesAsync on the Unit of Work
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(CustomerReview review)
        {
            await _unitOfWork.CustomerReviewRepository.UpdateReviewAsync(review);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _unitOfWork.CustomerReviewRepository.DeleteReviewAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
