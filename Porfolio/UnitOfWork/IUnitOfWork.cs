using Porfolio.Interfaces;

namespace Porfolio.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerReviewRepository CustomerReviewRepository { get; }
        IOrderRepository OrderRepository { get; }  // Example of another repository
        Task<int> SaveChangesAsync();  // Commit all changes within the transaction
    }
}
