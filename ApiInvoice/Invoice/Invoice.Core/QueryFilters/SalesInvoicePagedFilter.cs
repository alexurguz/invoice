using System;
namespace Invoice.Core.QueryFilters
{
    public class SalesInvoicePagedFilter
    {

        public int? pageSize { get; set; }

        public int? pageNumber { get; set; }
    }
}
