using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Core.Entities;
using Invoice.Core.Exceptions;
using Invoice.Core.Interfaces.UnitOfWork;
using Invoice.Core.Interfaces.UseCase;
using Invoice.Core.QueryFilters;
using Invoice.Common.Utilities;
using Invoice.Core.CustomEntities;
using Microsoft.Extensions.Options;

namespace Invoice.Core.UseCase
{
    public class SalesInvoiceUseCaseImpl : ISalesInvoiceUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public SalesInvoiceUseCaseImpl(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
        }
        /*
        public async Task<SalesInvoice> GetSalesInvoiceById(int id)
        {
            return await _unitOfWork.SalesInvoiceRepository.GetSalesInvoiceById(id);
        }

        public async Task<IEnumerable<SalesInvoice>> GetSalesInvoices()
        {
            return await _unitOfWork.SalesInvoiceRepository.GetSalesInvoices();
        }

        public async Task InsertSalesInvoice(SalesInvoice salesInvoice)
        {
            await _unitOfWork.SalesInvoiceRepository.InsertSalesInvoice(salesInvoice);
        }

        public async Task<bool> UpdateSalesInvoice(SalesInvoice salesInvoice)
        {
            return await _unitOfWork.SalesInvoiceRepository.UpdateSalesInvoice(salesInvoice);
        }

        public async Task<bool> DeleteSalesInvoice(int id)
        {
            return await _unitOfWork.SalesInvoiceRepository.DeleteSalesInvoice(id);
        }*/

        public IEnumerable<SalesInvoice> GetSalesInvoices(SalesInvoiceQueryFilter filters)
        {
            var salesInvoices = _unitOfWork.SalesInvoiceRepository.GetAll();

            if (filters.IdCustomer != null)
            {
                salesInvoices = salesInvoices.Where(s => s.IdCustomer == filters.IdCustomer);
            }

            if (filters.DateSales != null)
            {
                salesInvoices = salesInvoices.Where(s => s.DateSales.ToShortDateString() == filters.DateSales?.ToShortDateString());
            }

            if (filters.Address != null)
            {
                salesInvoices = salesInvoices.Where(s => s.Address == filters.Address);
            }

            if (filters.Country != null)
            {
                salesInvoices = salesInvoices.Where(s => s.Country == filters.Country);
            }

            if (filters.City != null)
            {
                salesInvoices = salesInvoices.Where(s => s.City == filters.City);
            }

            if (filters.Discount != null)
            {
                salesInvoices = salesInvoices.Where(s => s.Discount == filters.Discount);
            }

            if (filters.TotalWithoutDiscount != null)
            {
                salesInvoices = salesInvoices.Where(s => s.TotalWithoutDiscount == filters.TotalWithoutDiscount);
            }

            if (filters.Status != null)
            {
                salesInvoices = salesInvoices.Where(s => s.Status == filters.Status);
            }

            if (filters.CreateDate != null)
            {
                salesInvoices = salesInvoices.Where(s => s.CreateDate.ToShortDateString() == filters.CreateDate?.ToShortDateString());
            }

            if (filters.UpdateDate != null)
            {
                salesInvoices = salesInvoices.Where(s => s.UpdateDate.ToShortDateString() == filters.UpdateDate?.ToShortDateString());
            }

            salesInvoices = salesInvoices.Where(s => s.Deleted == Constants.ROW_NOT_DELETED);

            return salesInvoices;
        }

        public async Task<SalesInvoice> GetSalesInvoiceById(int id)
        {
            return await _unitOfWork.SalesInvoiceRepository.GetById(id);
        }

        public async Task InsertSalesInvoice(SalesInvoice salesInvoice)
        {
            //throw new BusinessException("User doesn't exist");
            await _unitOfWork.SalesInvoiceRepository.Add(salesInvoice);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateSalesInvoice(SalesInvoice salesInvoice)
        {
            _unitOfWork.SalesInvoiceRepository.Update(salesInvoice);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSalesInvoice(int id)
        {
            await _unitOfWork.SalesInvoiceRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public IEnumerable<SalesInvoice> GetSalesInvoicesByCustomer(int IdCustomer)
        {
            return _unitOfWork.SalesInvoiceRepository.GetSalesInvoicesByCustomer(IdCustomer);
        }

        public PagedList<SalesInvoice> GetSalesInvoicesPaged(SalesInvoicePagedFilter filters)
        {
            filters.pageNumber = (filters.pageNumber == 0 || filters.pageNumber == null) ? _paginationOptions.DefaultPageNumber : filters.pageNumber;
            filters.pageSize = (filters.pageSize == 0 || filters.pageSize == null) ? _paginationOptions.DefaultPageSize : filters.pageSize;

            var salesInvoices = _unitOfWork.SalesInvoiceRepository.GetAll();
                        
            salesInvoices = salesInvoices.Where(s => s.Deleted == Constants.ROW_NOT_DELETED);

            if (Helpers.IsIENumerableEmpty<SalesInvoice>(salesInvoices))
            {
                throw new NotFoundException("Invoices not found");
            }

            var pagedSongs = PagedList<SalesInvoice>.Create(salesInvoices, (int)filters.pageNumber, (int)filters.pageSize);
            return pagedSongs;
        }
    }
}