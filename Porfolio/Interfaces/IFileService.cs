using Porfolio.Model;

namespace Porfolio.Interfaces
{
    public interface IFileService
    {
        Task<FileDetails> UploadFileAsync(IFormFile file, string folderName);
        FileDetails GetFile(string folderName, string fileName);
        List<FileDetails> GetAllFiles(string folderName);
        Task<FileDetails> UpdateFileAsync(IFormFile newFile, string folderName, string existingFileName);
        bool DeleteFile(string folderName, string fileName);
        bool DeleteAllFiles(string folderName); 
    }
}
