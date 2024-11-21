namespace Porfolio.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerReviewRepository CustomerReviewRepository { get; }
        IOrderRepository OrderRepository { get; }  // Example of another repository
        Task<int> SaveChangesAsync();  // Commit all changes within the transaction
    }
}
