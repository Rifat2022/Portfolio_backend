
using Porfolio.Model;
using Porfolio.Repositories;
using Porfolio.Repositories.Interface;
using Porfolio.Services.Interface;

namespace Porfolio.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _repository;

        public FileService(IFileRepository repository)
        {
            _repository = repository;
        }

        // Upload File
        public async Task<FileDetails> UploadFileAsync(IFormFile file, string folderName)
        {
            return await _repository.UploadFile(file, folderName);
        }

        // Get File by Name
        public FileDetails GetFile(string folderName, string fileName)
        {
            return _repository.GetFile(folderName, fileName);
        }

        // Get All Files in a Folder
        public List<FileDetails> GetAllFiles(string folderName)
        {
            return _repository.GetAllFiles(folderName);
        }

        // Update File
        public async Task<FileDetails> UpdateFileAsync(IFormFile newFile, string folderName, string existingFileName)
        {
            return await _repository.UpdateFile(newFile, folderName, existingFileName);
        }

        // Delete File by Name
        public bool DeleteFile(string folderName, string fileName)
        {
            return _repository.DeleteFile(folderName, fileName);
        }

        // Delete All Files in a Folder
        public bool DeleteAllFiles(string folderName)
        {
            return _repository.DeleteAllFiles(folderName);
        }
    }

}
