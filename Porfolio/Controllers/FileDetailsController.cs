using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Porfolio.Model;
using Porfolio.Services.Interface;

namespace Porfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDetailsController : ControllerBase
    {
        private readonly IFileDetailsService _fileDetailsService;

        public FileDetailsController(IFileDetailsService fileDetailsService)
        {
            _fileDetailsService = fileDetailsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileDetails>>> GetAllFileDetails()
        {
            var fileDetails = await _fileDetailsService.GetAllFileDetailsAsync();
            return Ok(fileDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileDetails>> GetFileDetailsById(int id)
        {
            var fileDetails = await _fileDetailsService.GetFileDetailsByIdAsync(id);
            if (fileDetails == null) return NotFound();
            return Ok(fileDetails);
        }

        [HttpPost]
        public async Task<ActionResult<FileDetails>> AddFileDetails(FileDetails fileDetails)
        {
            var createdFileDetails = await _fileDetailsService.AddFileDetailsAsync(fileDetails);
            return CreatedAtAction(nameof(GetFileDetailsById), new { id = createdFileDetails.FileDetailsId }, createdFileDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFileDetails(int id, FileDetails fileDetails)
        {
            if (id != fileDetails.FileDetailsId) return BadRequest();

            var updatedFileDetails = await _fileDetailsService.UpdateFileDetailsAsync(fileDetails);
            return Ok(updatedFileDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileDetails(int id)
        {
            var isDeleted = await _fileDetailsService.DeleteFileDetailsAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
