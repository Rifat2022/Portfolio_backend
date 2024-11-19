using Porfolio.Data;
using Porfolio.Model;
using Microsoft.AspNetCore.StaticFiles;
using Porfolio.Interfaces;

namespace Porfolio.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly PortfolioContext _context;
        private readonly string _baseFolder;
        public FileRepository(PortfolioContext context)
        {
            _context = context;
            _baseFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images");
        }
        // Upload File
        public string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream"; // Default MIME type if unknown
            }
            return contentType;
        }
        public async Task<FileDetails> UploadFile(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            var uploadsFolder = Path.Combine(_baseFolder, folderName);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new FileDetails
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Path = Path.Combine(folderName, fileName).Replace("\\", "/")
            };
        }

        // Get a Single File by Name
        public FileDetails GetFile(string folderName, string fileName)
        {
            var filePath = Path.Combine(_baseFolder, folderName, fileName);
            if (!File.Exists(filePath)) return null;

            return new FileDetails
            {
                FileName = fileName,
                ContentType = GetMimeType(fileName),
                Path = Path.Combine(folderName, fileName).Replace("\\", "/")
            };
        }

        // Get All Files in a Folder
        public List<FileDetails> GetAllFiles(string folderName)
        {
            var folderPath = Path.Combine(_baseFolder, folderName);

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
                return new List<FileDetails>();

            // Create a FileExtensionContentTypeProvider instance
            var provider = new FileExtensionContentTypeProvider();

            // Get all files in the folder and map them to FileDetails
            return Directory.GetFiles(folderPath).Select(filePath =>
            {
                // Determine the ContentType
                if (!provider.TryGetContentType(filePath, out var contentType))
                {
                    contentType = "application/octet-stream"; // Default for unknown types
                }

                // Return FileDetails object
                return new FileDetails
                {
                    FileName = Path.GetFileName(filePath),
                    ContentType = contentType,
                    Path = Path.Combine(folderName, Path.GetFileName(filePath)).Replace("\\", "/")
                };
            }).ToList();
        }


        // Update File
        public async Task<FileDetails> UpdateFile(IFormFile newFile, string folderName, string existingFileName)
        {
            var existingFile = GetFile(folderName, existingFileName);
            if (existingFile != null)
            {
                DeleteFile(folderName, existingFileName);
            }

            return await UploadFile(newFile, folderName);
        }

        // Delete File by Name
        public bool DeleteFile(string folderName, string fileName)
        {
            var filePath = Path.Combine(_baseFolder, folderName, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        // Delete All Files in a Folder
        public bool DeleteAllFiles(string folderName)
        {
            var folderPath = Path.Combine(_baseFolder, folderName);
            if (!Directory.Exists(folderPath)) return false;

            var files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }
            return true;
        }


    }
}
