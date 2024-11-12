using Porfolio.Data;
using Porfolio.Interfaces;

namespace Porfolio.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PortfolioContext _context;
        public OrderRepository(PortfolioContext context)
        {
            _context = context;
        }
        // Define private backing fields for the properties
        private int _id;
        private DateTime _data;

        // Implement the Id property
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        // Implement the Data property
        public DateTime Data
        {
            get => _data;
            set => _data = value;
        }

        // Additional methods for OrderRepository can be implemented 
    }
}
