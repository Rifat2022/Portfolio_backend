using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Interfaces;
using Porfolio.Model;
using Porfolio.Services;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReview>>> GetReviews()
        {
            var reviews = await _customerReviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<CustomerReview>> CreateReview([FromForm] CustomerReview review, IFormFile file)
        {
            try
             {
                await _customerReviewService.CreateReviewAsync(review, file);

                return CreatedAtAction(nameof(CreateReview), new { id = review.Id }, review);
                // Read the multipart form data
                //var formCollection = await Request.ReadFormAsync(); 

                //// Extract the file
                //var file = formCollection.Files.FirstOrDefault();
                //if (file == null)
                //{
                //    return BadRequest("File is missing.");
                //}
                //// Extract the 'review' JSON string
                //var reviewJson = formCollection["review"];
                //if (string.IsNullOrEmpty(reviewJson))
                //{
                //    return BadRequest("Review data is missing.");
                //}

                //// Deserialize the JSON string into a CustomerReview object
                //var reviewObj = System.Text.Json.JsonSerializer.Deserialize<CustomerReview>(reviewJson);
                //if (string.IsNullOrWhiteSpace(reviewJson))
                //{
                //    return BadRequest("Review data is missing or invalid.");
                //}

                // Pass the file and review object to the service


                //var folderName = Path.Combine("Resources", "Images"); 
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                //if (file.Length > 0) 
                //{
                //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //    var fullPath = Path.Combine(pathToSave, fileName);
                //    var dbPath = Path.Combine(folderName, fileName);
                //    using (var stream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //    return Ok(new { dbPath });
                //}
                //else
                //{
                //    return BadRequest();
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            
            


            
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
