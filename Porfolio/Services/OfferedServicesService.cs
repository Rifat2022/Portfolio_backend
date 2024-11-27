using Porfolio.Model;
using Porfolio.Repositories;
using Porfolio.Repositories.Interface;
using Porfolio.Services.Interface;

namespace Porfolio.Services
{
    public class OfferedServicesService : IOfferedServicesService
    {
        private readonly IOfferedServiceRepository _offeredServiceRepository;
        public OfferedServicesService(IOfferedServiceRepository offeredServiceRepository)
        {
            _offeredServiceRepository  = offeredServiceRepository;
        }
        public async Task<OfferedService> CreateOfferedServiceAsync(OfferedService offeredService)
        {

            return await _offeredServiceRepository.CreateOfferedServiceAsync(offeredService);
        }

        public async Task<IEnumerable<OfferedService>> GetAllOfferedServicesAsync()
        {
            return await _offeredServiceRepository.GetAllOfferedServicesAsync();
        }

        public async Task<OfferedService?> GetOfferedServiceByIdAsync(int id)
        {
            return await _offeredServiceRepository.GetOfferedServiceByIdAsync(id);
        }

        public async Task<OfferedService?> UpdateOfferedServiceAsync(int id, OfferedService offeredService)
        {
            //write customer review logic or whatever            
            return await _offeredServiceRepository.UpdateOfferedServiceAsync(id, offeredService);
        }

        public async Task<bool> DeleteOfferedServiceAsync(int id)
        {
            return await _offeredServiceRepository.DeleteOfferedServiceAsync(id);
        }
    }
}
