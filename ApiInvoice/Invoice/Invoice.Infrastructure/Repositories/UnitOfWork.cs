using System.Threading.Tasks;
using Invoice.Core.Entities;
using Invoice.Core.Interfaces.Repository;
using Invoice.Core.Interfaces.UnitOfWork;
using Invoice.Infrastructure.Data;

namespace Invoice.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Product> _productRepository;
        private readonly ISalesInvoiceRepository _salesInvoiceRepository;
        private readonly IRepository<User> _userRepository;

        private readonly InvoiceDBContext _context;

        public UnitOfWork(InvoiceDBContext context)
        {
            _context = context;
        }

        public IRepository<Product> ProductRepository => _productRepository ?? new Repository<Product>(_context);
        public ISalesInvoiceRepository SalesInvoiceRepository => _salesInvoiceRepository ?? new SalesInvoiceRepository(_context);
        public IRepository<User> UserRepository => _userRepository ?? new Repository<User>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
