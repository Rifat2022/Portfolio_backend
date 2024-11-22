using Porfolio.Model;
using Porfolio.Repositories.Interface;
using Porfolio.Services.Interface;

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
    }
}
