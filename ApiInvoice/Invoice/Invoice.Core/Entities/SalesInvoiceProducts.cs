using System;
using System.Collections.Generic;

namespace Invoice.Core.Entities
{
    public partial class SalesInvoiceProducts : BaseEntity 
    {
        public int IdSalesInvoice { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual SalesInvoice IdSalesInvoiceNavigation { get; set; }
    }
}
