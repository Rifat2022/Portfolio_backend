using Porfolio.Model;

namespace Porfolio.Services.Interface
{
    public interface IOfferedServicesService
    {
        Task<OfferedService> CreateOfferedServiceAsync(OfferedService offeredService);
        Task<IEnumerable<OfferedService>> GetAllOfferedServicesAsync();
        Task<OfferedService?> GetOfferedServiceByIdAsync(int id);
        Task<OfferedService?> UpdateOfferedServiceAsync(int id, OfferedService offeredService);
        Task<bool> DeleteOfferedServiceAsync(int id);
    }
}
