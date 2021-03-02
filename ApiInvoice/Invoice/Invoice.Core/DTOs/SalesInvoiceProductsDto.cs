using System;
namespace Invoice.Core.DTOs
{
    public class SalesInvoiceProductsDto
    {
        public SalesInvoiceProductsDto()
        {
        }

        public int IdSalesInvoiceProduct { get; set; }
        public int IdSalesInvoice { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalValue { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
