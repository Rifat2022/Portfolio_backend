using Porfolio.Controllers;
using Porfolio.Model;
using Porfolio.Repositories.Interface;
using Porfolio.Services.Interface;
using System.IO;

namespace Porfolio.Services
{
    public class FileDetailsService : IFileDetailsService
    {
        private readonly IFileDetailsRepository _fileDetailsRepository;

        public FileDetailsService(IFileDetailsRepository fileDetailsRepository)
        {
            _fileDetailsRepository = fileDetailsRepository;
        }

        public async Task<IEnumerable<FileDetails>> GetAllFileDetailsAsync()
        {
            return await _fileDetailsRepository.GetAllFileDetailsAsync();
        }

        public async Task<FileDetails> GetFileDetailsByIdAsync(int id)
        {
            return await _fileDetailsRepository.GetFileDetailsByIdAsync(id);
        }

        public async Task<FileDetails> AddFileDetailsAsync(FileDetails fileDetails)
        {
            return await _fileDetailsRepository.AddFileDetailsAsync(fileDetails);
        }

        public async Task<FileDetails> UpdateFileDetailsAsync(FileDetails fileDetails)
        {
            return await _fileDetailsRepository.UpdateFileDetailsAsync(fileDetails);
        }

        public async Task<bool> DeleteFileDetailsAsync(int id)
        {
            return await _fileDetailsRepository.DeleteFileDetailsAsync(id);
        }
        public async Task<FileDetails> GetFileDetailsFromFile(IFormFile file)
        {
            try
            {
                // Read the file data
                if (file == null)
                {
                    throw new ArgumentNullException(nameof(file), "File cannot be null.");
                }
                if (file.Length > 10 * 1024 * 1024) // Example: 10 MB limit
                {
                    throw new InvalidOperationException("File size exceeds the maximum allowed limit.");
                }
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var fileDetails = new FileDetails
                {
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    Data = memoryStream.ToArray(), 
                    Path = "", 
                };
                return fileDetails;
            }
            catch (Exception ex) 
            {
                // Log the exception
                throw new InvalidOperationException("Error occurred while processing the file.", ex);
            }
        }
    }
}
