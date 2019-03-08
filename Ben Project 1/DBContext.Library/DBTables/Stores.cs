using System;
using System.Collections.Generic;

namespace DBContext.Library
{
    public partial class Stores
    {
        public Stores()
        {
            Customers = new HashSet<Customers>();
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        public string Location { get; set; }
        public int DeluxePackageRemaining { get; set; }
        public decimal ShippingCosts { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
