using System;
using System.Collections.Generic;

namespace Invoice.Core.Entities
{
    public partial class SalesInvoice : BaseEntity
    {
        public SalesInvoice()
        {
            SalesInvoiceProducts = new HashSet<SalesInvoiceProducts>();
        }

        public int IdCustomer { get; set; }
        public DateTime DateSales { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal TotalWithoutDiscount { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual User IdCustomerNavigation { get; set; }
        public virtual ICollection<SalesInvoiceProducts> SalesInvoiceProducts { get; set; }
    }
}
