using Porfolio.Model;

namespace Porfolio.Services.Interface
{
    public interface IFileDetailsService
    {
        Task<IEnumerable<FileDetails>> GetAllFileDetailsAsync();
        Task<FileDetails> GetFileDetailsByIdAsync(int id);
        Task<FileDetails> AddFileDetailsAsync(FileDetails fileDetails);
        Task<FileDetails> UpdateFileDetailsAsync(FileDetails fileDetails);
        Task<bool> DeleteFileDetailsAsync(int id);
    }
}
