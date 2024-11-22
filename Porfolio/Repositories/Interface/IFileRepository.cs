using Porfolio.Model;

namespace Porfolio.Repositories.Interface
{
    public interface IFileRepository
    {
        Task<FileDetails> UploadFile(IFormFile file, string folderName);
        FileDetails GetFile(string folderName, string fileName);
        List<FileDetails> GetAllFiles(string folderName);
        Task<FileDetails> UpdateFile(IFormFile newFile, string folderName, string existingFileName);
        bool DeleteFile(string folderName, string fileName);
        bool DeleteAllFiles(string folderName);
    }
}
