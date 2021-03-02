using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Common.Utilities;
using Invoice.Core.Entities;
using Invoice.Core.Interfaces.Repository;
using Invoice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class SalesInvoiceRepository : Repository<SalesInvoice>, ISalesInvoiceRepository
    {
        /*
        private readonly ApiTestContext _context;
        public SalesInvoiceRepository(ApiTestContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesInvoice> GetSalesInvoices()
        {
            var salesInvoices = _context.SalesInvoice.Where(si => si.Deleted == Constants.ROW_NOT_DELETED).AsEnumerable();
            
            return salesInvoices;
        }

        public async Task<SalesInvoice> GetSalesInvoiceById(int id)
        {
            var salesInvoice = await _context.SalesInvoice.FirstOrDefaultAsync(si => si.id == id && si.Deleted == Constants.ROW_NOT_DELETED);

            return salesInvoice;
        }

        public async Task InsertSalesInvoice(SalesInvoice salesInvoice)
        {
            _context.SalesInvoice.Add(salesInvoice);
            await _context.SaveChangesAsync();
        }

        public async void UpdateSalesInvoice(SalesInvoice salesInvoice)
        {
            var currentSaleInvoice = await GetSalesInvoiceById(salesInvoice.id);
            currentSaleInvoice.IdCustomer = salesInvoice.IdCustomer;
            currentSaleInvoice.DateSales = salesInvoice.DateSales;
            currentSaleInvoice.Address = salesInvoice.Address;
            currentSaleInvoice.Country = salesInvoice.Country;
            currentSaleInvoice.City = salesInvoice.City;
            currentSaleInvoice.Discount = salesInvoice.Discount;
            currentSaleInvoice.Total = salesInvoice.Total;
            currentSaleInvoice.TotalWithoutDiscount = salesInvoice.TotalWithoutDiscount;
            currentSaleInvoice.Status = salesInvoice.Status;
            currentSaleInvoice.CreateDate = currentSaleInvoice.CreateDate;
            currentSaleInvoice.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeleteSalesInvoice(int id)
        {
            var currentSaleInvoice = await GetSalesInvoiceById(id);
            currentSaleInvoice.Deleted = Constants.ROW_DELETED;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }*/

        public SalesInvoiceRepository(InvoiceDBContext context) : base(context) { }

        public IEnumerable<SalesInvoice> GetSalesInvoicesByCustomer(int IdCustomer)
        {
            return _entities.Where(s => s.IdCustomer == IdCustomer).AsEnumerable();
        }

    }
}