using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Model;
using Porfolio.Services;
using Porfolio.Services.Interface;
using System.Net.Http.Headers;

namespace Porfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewService _customerReviewService;
        public CustomerReviewController(ICustomerReviewService customerReviewService)
        {
            _customerReviewService = customerReviewService;
        }
        // Create a CustomerReview with FileDetails
        [HttpPost]
        public async Task<IActionResult> CreateCustomerReview([FromBody] CustomerReview review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdReview = await _customerReviewService.CreateCustomerReviewAsync(review);
            return CreatedAtAction(nameof(GetCustomerReviewById), new { id = createdReview.Id }, createdReview);
        }

        // Get all CustomerReviews with FileDetails
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerReviews()
        {
            var reviews = await _customerReviewService.GetAllCustomerReviewsAsync();
            return Ok(reviews);
        }

        // Get a CustomerReview by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerReviewById(int id)
        {
            var review = await _customerReviewService.GetCustomerReviewByIdAsync(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        // Update a CustomerReview
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerReview(int id, [FromBody] CustomerReview review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedReview = await _customerReviewService.UpdateCustomerReviewAsync(id, review);
            if (updatedReview == null)
                return NotFound();
            return Ok(updatedReview);
        }

        // Delete a CustomerReview
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerReview(int id)
        {
            var success = await _customerReviewService.DeleteCustomerReviewAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

    }
}
