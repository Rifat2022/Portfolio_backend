using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Porfolio.Model;
using Porfolio.Services.Interface;

namespace Porfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferedServicesController : ControllerBase
    {
        private readonly IOfferedServicesService _offeredService;
        public OfferedServicesController(IOfferedServicesService offeredService)
        {
            _offeredService = offeredService;
        }

        [HttpPost]
        //[FromBody] for string data [FromForm] for FormData 
        public async Task<IActionResult> CreateofferedService()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var offeredServiceJson = formCollection["OfferedService"];
                if (string.IsNullOrEmpty(offeredServiceJson))
                {
                    return BadRequest("offeredService data is missing or invalid.");
                }
                var offeredService = JsonConvert.DeserializeObject<OfferedService>(offeredServiceJson);
                if (offeredService == null)
                {
                    return BadRequest("Failed to deserialize offeredService data.");
                }
                var createdOfferedService = await _offeredService.CreateOfferedServiceAsync(offeredService);
                return CreatedAtAction(nameof(GetofferedServiceById), new { id = createdOfferedService.OfferedServiceId }, createdOfferedService);
            }
            catch (Exception exception)
            {
                return StatusCode(500, "An error occurred while processing your request.\n" + new { exception.Message });
            }
        }

        // Get all offeredServices with FileDetails
        [HttpGet]
        public async Task<IActionResult> GetAllofferedServices()
        {
            var offeredServices = await _offeredService.GetAllOfferedServicesAsync();
            return Ok(offeredServices);
        }

        // Get a offeredService by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetofferedServiceById(int id)
        {
            var offeredService = await _offeredService.GetOfferedServiceByIdAsync(id);
            if (offeredService == null)
            {
                return NotFound();
            }
            return Ok(offeredService);
        }

        // Update a offeredService
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateofferedService(int id)
        {
            try
            {
                // Validate the model state
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Parse the form collection
                var formCollection = await Request.ReadFormAsync();

                if (!formCollection.TryGetValue("UpdatedOfferedService", out var updatedOfferedServiceJson) || string.IsNullOrEmpty(updatedOfferedServiceJson))
                {
                    return BadRequest("offeredService data is missing or invalid.");
                }

                // Deserialize the JSON string into a offeredService object
                var offeredService = JsonConvert.DeserializeObject<OfferedService>(updatedOfferedServiceJson);

                // Call the service to update the review
                var updatedOfferedService = await _offeredService.UpdateOfferedServiceAsync(id, offeredService);
                if (updatedOfferedService == null)
                {
                    return NotFound();
                }

                // Return the updated review
                return CreatedAtAction(nameof(GetofferedServiceById), new { id = updatedOfferedService.OfferedServiceId }, updatedOfferedService);
            }
            catch (Exception exception)
            {
                return StatusCode(500, "An error occurred while processing your request.\n" + new { exception.Message });
            }
        }

        // Delete a offeredService
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteofferedService(int id)
        {
            bool success = await _offeredService.DeleteOfferedServiceAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(new { message = "File Deleted!" });
        }

    }
}
