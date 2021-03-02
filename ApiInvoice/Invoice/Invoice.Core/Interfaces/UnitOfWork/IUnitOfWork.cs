using System;
using System.Threading.Tasks;
using Invoice.Core.Entities;
using Invoice.Core.Interfaces.Repository;

namespace Invoice.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        ISalesInvoiceRepository SalesInvoiceRepository { get; }
        IRepository<User> UserRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
