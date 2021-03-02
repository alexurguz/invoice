using System;
using Invoice.Core.CustomEntities;

namespace Invoce.Api.Responses
{
    public class SalesInvoiceResponse<T>
    {
        public SalesInvoiceResponse(T invoices)
        {
            Invoices = invoices;
        }
        public T Invoices { get; set; }

        public PaginatorData paginator { get; set; }
    }
}
