using Porfolio.Model;

namespace Porfolio.Repositories.Interface
{
    public interface IFileDetailsRepository
    {
        Task<IEnumerable<FileDetails>> GetAllFileDetailsAsync();
        Task<FileDetails> GetFileDetailsByIdAsync(int id);
        Task<FileDetails> AddFileDetailsAsync(FileDetails fileDetails);
        Task<FileDetails> UpdateFileDetailsAsync(FileDetails fileDetails);
        Task<bool> DeleteFileDetailsAsync(int id);
    }
}
