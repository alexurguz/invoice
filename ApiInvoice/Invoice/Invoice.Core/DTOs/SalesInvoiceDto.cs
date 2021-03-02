using System;
using System.Collections.Generic;

namespace Invoice.Core.DTOs
{
    public class SalesInvoiceDto
    {
        public SalesInvoiceDto()
        {
        }

        public int IdSalesInvoice { get; set; }
        public int IdCustomer { get; set; }
        public DateTime DateSales { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalWithoutDiscount { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<SalesInvoiceProductsDto> SalesInvoiceProducts { get; set; }
    }
}
