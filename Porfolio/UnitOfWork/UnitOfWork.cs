using Porfolio.Data;
using Porfolio.Interfaces;
using Porfolio.Repositories;

namespace Porfolio.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioContext _context;
        private ICustomerReviewRepository _customerReviewRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(PortfolioContext context)
        {
            _context = context;
        }

        // Lazy initialization of repositories
        public ICustomerReviewRepository CustomerReviewRepository =>
            _customerReviewRepository ??= new CustomerReviewRepository(_context);

        public IOrderRepository OrderRepository =>
            _orderRepository ??= new OrderRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
