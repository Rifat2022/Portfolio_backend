using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Model;
using Porfolio.Repositories.Interface;

namespace Porfolio.Repositories
{
    public class OfferedServiceRepository : IOfferedServiceRepository
    {
        private readonly PortfolioContext _context;

        public OfferedServiceRepository(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<OfferedService> CreateOfferedServiceAsync(OfferedService offeredService)
        {
            if (offeredService == null)
            {
                throw new ArgumentNullException(nameof(offeredService), "OfferedService cannot be null.");
            }

            try
            {
                _context.OfferedServices.Add(offeredService);
                await _context.SaveChangesAsync();
                return offeredService;
            }
            catch (Exception e)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error occurred while saving OfferedService: {e.Message}");
                // Rethrow the exception to be handled by a higher layer
                throw new InvalidOperationException("Failed to oseate the customer OfferedService.", e);
            }
        }


        public async Task<IEnumerable<OfferedService>> GetAllOfferedServicesAsync()
        {
            return await _context.OfferedServices
                .ToListAsync();
        }

        public async Task<OfferedService?> GetOfferedServiceByIdAsync(int id)
        {
            return await _context.OfferedServices.Include(os => os.OfferedServiceId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<OfferedService?> UpdateOfferedServiceAsync(int id, OfferedService OfferedService)
        {
            var existingOfferedService = await _context.OfferedServices
                .FirstOrDefaultAsync(os => os.OfferedServiceId == id);
            if (existingOfferedService == null)
                return null;

            existingOfferedService.description = OfferedService.description;
            existingOfferedService.service_name = OfferedService.service_name;
            existingOfferedService.bootstrap_icon_code = OfferedService.bootstrap_icon_code;
            existingOfferedService.headings = OfferedService.headings;
            existingOfferedService.quote = OfferedService.headings;

            // Update FileDetails if provided

            await _context.SaveChangesAsync();
            return existingOfferedService;
        }

        public async Task<bool> DeleteOfferedServiceAsync(int id)
        {
            var OfferedService = await _context.OfferedServices
                .FirstOrDefaultAsync(os => os.OfferedServiceId == id);
            if (OfferedService == null)
                return false;

            _context.OfferedServices.Remove(OfferedService);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

