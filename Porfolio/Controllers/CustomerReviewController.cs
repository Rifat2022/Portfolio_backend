using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Model;
using Porfolio.Services;

namespace Porfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly CustomerReviewService _customerReviewService;
        public CustomerReviewController(CustomerReviewService customerReviewService)
        {
            _customerReviewService = customerReviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReview>>> GetReviews()
        {
            var reviews = await _customerReviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReview>> CreateReview(CustomerReview review, IFormFile file)
        {
            await _customerReviewService.AddReviewAsync(review, file);
            return CreatedAtAction(nameof(GetReviews), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, CustomerReview review)
        {
            if (id != review.Id) return BadRequest();
            await _customerReviewService.UpdateReviewAsync(review);
            return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _customerReviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
