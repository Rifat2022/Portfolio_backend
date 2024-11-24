using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Porfolio.Data;
using Porfolio.Model;
using Porfolio.Services;
using Porfolio.Services.Interface;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        //[FromBody] CustomerReview review
        public async Task<IActionResult> CreateCustomerReview()
        {
            try
            {
                //var files = Request.Form.Files;
                //var formCollection = await Request.ReadFormAsync();
                //var files = formCollection.Files;
                //foreach (var file in files)
                //{

                //}
                //var folderName = Path.Combine("StaticFiles", "Images");
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.FirstOrDefault();

                // Retrieve the CustomerReview JSON string from the form data
                var customerReviewJson = formCollection["CustomerReview"];
                if (string.IsNullOrEmpty(customerReviewJson))
                {
                    return BadRequest("CustomerReview data is missing or invalid.");
                }

                // Deserialize the CustomerReview object
                var customerReview = JsonConvert.DeserializeObject<CustomerReview>(customerReviewJson);
                if (customerReview == null)
                {
                    return BadRequest("Failed to deserialize CustomerReview data.");
                }

                // Ensure the file is not null if it's required
                if (file == null)
                {
                    return BadRequest("File is missing.");
                }

                // Create the customer review
                var createdReview = await _customerReviewService.CreateCustomerReviewAsync(customerReview, file);
                return CreatedAtAction(nameof(GetCustomerReviewById), new { id = createdReview.Id }, createdReview);

            }
            catch (Exception exception)
            {
                return StatusCode(500, "An error occurred while processing your request.\n"+ new { exception.Message });
            }
            
            //if (!ModelState.IsValid)
            //{
            //    foreach (var state in ModelState)
            //    {
            //        Console.WriteLine($"{state.Key}: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
            //    }
            //    return BadRequest(ModelState);
            //}

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
