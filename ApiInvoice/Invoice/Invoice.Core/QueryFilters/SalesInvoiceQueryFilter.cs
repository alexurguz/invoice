using System;
namespace Invoice.Core.QueryFilters
{
    public class SalesInvoiceQueryFilter
    {
        public int? IdCustomer { get; set; }
        public DateTime? DateSales { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalWithoutDiscount { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? pageSize { get; set; }
        public int? pageNumber { get; set; }
    }
}
