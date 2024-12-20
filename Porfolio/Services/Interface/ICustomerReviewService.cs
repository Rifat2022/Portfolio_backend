﻿using Porfolio.Model;

namespace Porfolio.Services.Interface
{
    public interface ICustomerReviewService
    {
        Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review, IFormFile file);
        Task<IEnumerable<CustomerReview>> GetAllCustomerReviewsAsync();
        Task<CustomerReview?> GetCustomerReviewByIdAsync(int id);
        Task<CustomerReview?> UpdateCustomerReviewAsync(int id, CustomerReview review, IFormFile file); 
        Task<bool> DeleteCustomerReviewAsync(int id);
    }
}
