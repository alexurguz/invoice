using System;
using System.Collections.Generic;

namespace Invoice.Core.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            SalesInvoice = new HashSet<SalesInvoice>();
        }

        public string Names { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<SalesInvoice> SalesInvoice { get; set; }
    }
}
