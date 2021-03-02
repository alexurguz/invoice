using System;
using System.Collections.Generic;

namespace Invoice.Core.Entities
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            SalesInvoiceProducts = new HashSet<SalesInvoiceProducts>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<SalesInvoiceProducts> SalesInvoiceProducts { get; set; }
    }
}
