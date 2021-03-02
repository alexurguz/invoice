using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Core.CustomEntities;
using Invoice.Core.Entities;
using Invoice.Core.QueryFilters;

namespace Invoice.Core.Interfaces.UseCase
{
    public interface ISalesInvoiceUseCase
    {
        PagedList<SalesInvoice> GetSalesInvoicesPaged(SalesInvoicePagedFilter filters);
        IEnumerable<SalesInvoice> GetSalesInvoices(SalesInvoiceQueryFilter filters);
        Task<SalesInvoice> GetSalesInvoiceById(int id);
        Task InsertSalesInvoice(SalesInvoice salesInvoice);
        Task<bool> UpdateSalesInvoice(SalesInvoice salesInvoice);
        Task<bool> DeleteSalesInvoice(int id);
        IEnumerable<SalesInvoice> GetSalesInvoicesByCustomer(int IdCustomer);
    }
}
