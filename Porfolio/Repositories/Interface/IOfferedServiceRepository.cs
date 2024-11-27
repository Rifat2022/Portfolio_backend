using Porfolio.Model;

namespace Porfolio.Repositories.Interface
{
    public interface IOfferedServiceRepository
    {

        Task<OfferedService> CreateOfferedServiceAsync(OfferedService offeredService);
        Task<OfferedService?> GetOfferedServiceByIdAsync(int id);
        Task<IEnumerable<OfferedService>> GetAllOfferedServicesAsync(); 
        Task<OfferedService?> UpdateOfferedServiceAsync(int id, OfferedService review);
        Task<bool>  DeleteOfferedServiceAsync(int id);
    }
}
