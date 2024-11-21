﻿using Microsoft.AspNetCore.Mvc;
using Porfolio.Model;

namespace Porfolio.Interfaces
{
    public interface ICustomerReviewRepository
    {
        Task<List<CustomerReview>> GetAllReviewsAsync();
        Task<CustomerReview?> GetReviewByIdAsync(int id);
        Task<CustomerReview> AddReviewAsync(CustomerReview review); 
        Task UpdateReviewAsync(CustomerReview review);
        Task DeleteReviewAsync(int id);
    }
}
