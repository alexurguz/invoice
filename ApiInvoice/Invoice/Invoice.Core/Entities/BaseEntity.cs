using System;
namespace Invoice.Core.Entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }
        public bool Deleted { get; set; }
    }
}
