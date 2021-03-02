using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.Entities;

namespace Invoice.Core.Interfaces.Repository
{
    public interface ISalesInvoiceRepository : IRepository<SalesInvoice>
    {
        /*
        IEnumerable<SalesInvoice> GetSalesInvoices();
        Task<SalesInvoice> GetSalesInvoiceById(int id);
        Task InsertSalesInvoice(SalesInvoice salesInvoice);
        void UpdateSalesInvoice(SalesInvoice salesInvoice);
        Task<bool> DeleteSalesInvoice(int id);
        */
        IEnumerable<SalesInvoice> GetSalesInvoicesByCustomer(int IdCustomer);
    }
}
