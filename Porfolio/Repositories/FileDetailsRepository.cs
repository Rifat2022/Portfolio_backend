using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Model;
using Porfolio.Repositories.Interface;

namespace Porfolio.Repositories
{
    public class FileDetailsRepository : IFileDetailsRepository
    {
        private readonly PortfolioContext? _context;

        public FileDetailsRepository(PortfolioContext? context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<FileDetails>> GetAllFileDetailsAsync()
        {
            return await _context.FileDetails.ToListAsync();
        }

        public async Task<FileDetails> GetFileDetailsByIdAsync(int id)
        {
            return await _context.FileDetails.FindAsync(id);
        }

        public async Task<FileDetails> AddFileDetailsAsync(FileDetails fileDetails)
        {
            await _context.FileDetails.AddAsync(fileDetails);
            await _context.SaveChangesAsync();
            return fileDetails;
        }

        public async Task<FileDetails> UpdateFileDetailsAsync(FileDetails fileDetails)
        {
            _context.FileDetails.Update(fileDetails);
            await _context.SaveChangesAsync();
            return fileDetails;
        }

        public async Task<bool> DeleteFileDetailsAsync(int id)
        {
            var fileDetails = await _context.FileDetails.FindAsync(id);
            if (fileDetails == null) return false;

            _context.FileDetails.Remove(fileDetails);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
